﻿using Rhino;
using Rhino.Commands;
using Rhino.Input.Custom;
using Rhino.UI;

namespace LayerStalker
{
    [System.Runtime.InteropServices.Guid("c742f6fc-5831-4d08-8d24-8354708d20f9")]
    public class LayerStalkerCommand : Command
    {
        public LayerStalkerCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static LayerStalkerCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "RhinoPanelD3Command"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panel_id = LayerStalkerControl.PanelId;
            var visible = Panels.IsPanelVisible(panel_id);

            var prompt = visible
              ? "Sample panel is visible. New value"
              : "Sample Manager panel is hidden. New value";

            var go = new GetOption();
            go.SetCommandPrompt(prompt);
            var hide_index = go.AddOption("Hide");
            var show_index = go.AddOption("Show");
            var toggle_index = go.AddOption("Toggle");

            go.Get();
            if (go.CommandResult() != Result.Success)
                return go.CommandResult();

            var option = go.Option();
            if (null == option)
                return Result.Failure;

            var index = option.Index;

            if (index == hide_index)
            {
                if (visible)
                    Panels.ClosePanel(panel_id);
            }
            else if (index == show_index)
            {
                if (!visible)
                    Panels.OpenPanel(panel_id);
            }
            else if (index == toggle_index)
            {
                if (visible)
                    Panels.ClosePanel(panel_id);
                else
                    Panels.OpenPanel(panel_id);
            }

            return Result.Success;
        }
    }
}
