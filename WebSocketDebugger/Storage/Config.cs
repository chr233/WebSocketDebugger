using WebSocketDebugger.Data;

namespace WebSocketDebugger.Storage
{
    internal class Config
    {
        public int FormWidth { get; set; } = 550;
        public int FormHeight { get; set; } = 660;
        public bool FormMaximised { get; set; }
        public string WebSocketUri { get; set; } = "";
        public bool KeepMessage { get; set; } = true;
        public HashSet<TemplateData> Templates { get; set; } = new();
    }
}
