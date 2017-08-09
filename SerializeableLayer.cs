using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Rhino;

namespace LayerStalker
{
    public class SerializeableLayer
    {
        [JsonProperty("id")]
        public Guid Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent")]
        public Guid? ParentId { get; set; }

        public int LayerIndex { get; set; }

        public string LayerColor { get; set; }

        public bool IsExp { get; set; }

        public bool IsLocked { get; set; }

        public bool IsVisible { get; set; }

        public int Size { get; set; }

        public string CurrLayer { get; set; }

        public List<string> Predecessors { get; set; }

        public Rhino.DocObjects.RhinoObject[] Objects { get; set; }

        public SerializeableLayer() { }
    }
}
