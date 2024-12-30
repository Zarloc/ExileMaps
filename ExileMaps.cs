using ExileCore2;
using ExileCore2.PoEMemory.MemoryObjects;
using ExileCore2.PoEMemory.Elements.AtlasElements;
using System.Linq;

using System.Numerics;

using System.Drawing;
using ExileCore2.PoEMemory;
namespace ExileMaps;


public class ExileMaps : BaseSettingsPlugin<ExileMapsSettings>
{
    private IngameState State => GameController.IngameState;

    public override bool Initialise()
    {
        //Perform one-time initialization here

        //Maybe load you custom config (only do so if builtin settings are inadequate for the job)
        //var configPath = Path.Join(ConfigDirectory, "custom_config.txt");
        //if (File.Exists(configPath))
        //{
        //    var data = File.ReadAllText(configPath);
        //}

        return true;
    }

    public override void AreaChange(AreaInstance area)
    {
        //Perform once-per-zone processing here
        //For example, Radar builds the zone map texture here
    }

    public override void Tick()
    {
        //Perform non-render-related work here, e.g. position calculation.
        //This method is still called on every frame, so to really gain
        //an advantage over just throwing everything in the Render method
        //you have to return a custom job, but this is a bit of an advanced technique
        //here's how, just in case:
        //return new Job($"{nameof(ExileMaps)}MainJob", () =>
        //{
        //    var a = Math.Sqrt(7);
        //});

        //otherwise, just run your code here
        //var a = Math.Sqrt(7);
        return;
    }

    public override void Render()
    {
        var WorldMap = State.IngameUi.WorldMap.AtlasPanel;

        if (!WorldMap.IsVisible)
            return;


        // Get all the map nodes
        var mapNodes = WorldMap.Descriptions;//.FindAll(x => x.Element.IsUnlocked && !x.Element.IsVisited);

        var zigguratNode = mapNodes.Find(x => x.Element.Area.Name.Contains("Ziggurat"));
        // Visible Nodes
        var visibleNodes = mapNodes.FindAll(x => x.Element.IsVisible);

        // Visited Nodes - not used yet
        // var visitedNodes = visibleNodes.FindAll(x => x.Element.IsVisited);

        // Locked Nodes
        var lockedNodes = visibleNodes.FindAll(x => !x.Element.IsUnlocked);

        // Unlocked Nodes
        var unlockedNodes = visibleNodes.FindAll(x => x.Element.IsUnlocked);

        // Invisible Nodes
        var invisibleNodes = mapNodes.FindAll(x => !x.Element.IsVisible);

        // Draw Unlocked nodes
        if (Settings.Features.UnlockedNodes) {
            foreach (var mapNode in unlockedNodes)
            {
                var nodeContent = mapNode.Element.Content;
                bool hasBreach =  Settings.Highlights.HighlightBreaches && nodeContent.Any(x => x.Name.Contains("Breach"));
                bool hasDelirium = Settings.Highlights.HighlightDelirium && nodeContent.Any(x => x.Name.Contains("Delirium"));
                bool hasExpedition = Settings.Highlights.HighlightExpedition && nodeContent.Any(x => x.Name.Contains("Expedition"));
                bool hasRitual = Settings.Highlights.HighlightRitual && nodeContent.Any(x => x.Name.Contains("Ritual"));
                bool hasBoss = Settings.Highlights.HighlightBosses && nodeContent.Any(x => x.Name.Contains("Boss"));
                bool isUntaintedParadise = Settings.Highlights.HighlightUntaintedParadise && mapNode.Element.Area.Id.Contains("UntaintedParadise");
                bool isTrader = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Id.Contains("Merchant");
                bool isCitadel = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Name.Contains("Citadel");

                var ringCount = 0;
                
                if (hasBreach)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.breachColor);
                    ringCount++;
                }
                if (hasDelirium)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.deliriumColor);
                    ringCount++;
                }
                if (hasExpedition)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.expeditionColor);
                    ringCount++;
                }
                if (hasRitual)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.ritualColor);
                    ringCount++;
                }
                if (hasBoss)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.bossColor);
                    ringCount++;
                }
                if (isUntaintedParadise)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.untaintedParadiseColor);

                    if (Settings.Highlights.LineToParadise)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.untaintedParadiseColor);
                    
                    ringCount++;
                }
                if (isTrader)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.traderColor);

                    if (Settings.Highlights.LineToTrader)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.traderColor);

                    ringCount++;
                }
                if (isCitadel)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.citadelColor);

                    if (Settings.Highlights.LineToCitadel)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.citadelColor);

                    ringCount++;
                }
                if (Settings.Features.UnlockedNames)
                {
                    DrawMapName(mapNode);
                }
            }
        }
        if (Settings.Features.LockedNodes) {
            foreach (var mapNode in lockedNodes)
            {
                var nodeContent = mapNode.Element.Content;
                bool hasBreach =  Settings.Highlights.HighlightBreaches && nodeContent.Any(x => x.Name.Contains("Breach"));
                bool hasDelirium = Settings.Highlights.HighlightDelirium && nodeContent.Any(x => x.Name.Contains("Delirium"));
                bool hasExpedition = Settings.Highlights.HighlightExpedition && nodeContent.Any(x => x.Name.Contains("Expedition"));
                bool hasRitual = Settings.Highlights.HighlightRitual && nodeContent.Any(x => x.Name.Contains("Ritual"));
                bool hasBoss = Settings.Highlights.HighlightBosses && nodeContent.Any(x => x.Name.Contains("Boss"));
                bool isUntaintedParadise = Settings.Highlights.HighlightUntaintedParadise && mapNode.Element.Area.Id.Contains("UntaintedParadise");
                bool isTrader = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Id.Contains("Trader");
                bool isCitadel = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Name.Contains("Citadel");

                var ringCount = 0;
                
                if (hasBreach)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.breachColor);
                    ringCount++;
                }
                if (hasDelirium)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.deliriumColor);
                    ringCount++;
                }
                if (hasExpedition)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.expeditionColor);
                    ringCount++;
                }
                if (hasRitual)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.ritualColor);
                    ringCount++;
                }
                if (hasBoss)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.bossColor);
                    ringCount++;
                }
                if (isUntaintedParadise)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.untaintedParadiseColor);

                    if (Settings.Highlights.LineToParadise)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.untaintedParadiseColor);
                    
                    ringCount++;
                }
                if (isTrader)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.traderColor);

                    if (Settings.Highlights.LineToTrader)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.traderColor);

                    ringCount++;
                }
                if (isCitadel)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.citadelColor);

                    if (Settings.Highlights.LineToCitadel)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.citadelColor);

                    ringCount++;
                }

                if (Settings.Features.LockedNames)
                {
                    DrawMapName(mapNode);
                }
            }
        }
        
        if (Settings.Features.UnrevealedNodes) {
            foreach (var mapNode in invisibleNodes)
            {
                var nodeContent = mapNode.Element.Content;
                bool hasBreach =  Settings.Highlights.HighlightBreaches && nodeContent.Any(x => x.Name.Contains("Breach"));
                bool hasDelirium = Settings.Highlights.HighlightDelirium && nodeContent.Any(x => x.Name.Contains("Delirium"));
                bool hasExpedition = Settings.Highlights.HighlightExpedition && nodeContent.Any(x => x.Name.Contains("Expedition"));
                bool hasRitual = Settings.Highlights.HighlightRitual && nodeContent.Any(x => x.Name.Contains("Ritual"));
                bool hasBoss = Settings.Highlights.HighlightBosses && nodeContent.Any(x => x.Name.Contains("Boss"));
                bool isUntaintedParadise = Settings.Highlights.HighlightUntaintedParadise && mapNode.Element.Area.Id.Contains("UntaintedParadise");
                bool isTrader = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Id.Contains("Merchant");
                bool isCitadel = Settings.Highlights.HighlightTrader && mapNode.Element.Area.Name.Contains("Citadel");

                var ringCount = 0;
                
                if (hasBreach)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.breachColor);
                    ringCount++;
                }
                if (hasDelirium)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.deliriumColor);
                    ringCount++;
                }
                if (hasExpedition)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.expeditionColor);
                    ringCount++;
                }
                if (hasRitual)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.ritualColor);
                    ringCount++;
                }
                if (hasBoss)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.bossColor);
                    ringCount++;
                }
                if (isUntaintedParadise)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.untaintedParadiseColor);

                    if (Settings.Highlights.LineToParadise)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.untaintedParadiseColor);
                    
                    ringCount++;
                }
                if (isTrader)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.traderColor);

                    if (Settings.Highlights.LineToTrader)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.traderColor);

                    ringCount++;
                }
                if (isCitadel)
                {
                    HighlightMapNode(mapNode, ringCount, Settings.Graphics.citadelColor);

                    if (Settings.Highlights.LineToCitadel)
                        DrawLineToMapNode(mapNode, zigguratNode, Settings.Graphics.citadelColor);

                    ringCount++;
                }

                if (Settings.Features.UnrevealedNames)
                {
                    DrawMapName(mapNode);
                }


            }
        }

        if (Settings.Features.DebugMode)
        {
            foreach (var mapNode in mapNodes)
            {
                var text = mapNode.Address.ToString("X");

                // text += $"\n{mapNode.Element.Area.Name}";

                // var mapContent = mapNode.Element.Content;
                // // Draw list of content on map
                // foreach (var content in mapContent)
                // {
                //     text += $"\n{content.Name}";
                // }
                Graphics.DrawText(text, mapNode.Element.GetClientRect().TopLeft, Color.Red);
            }
        }
        // Draw description address on each map node


        //Any Imgui or Graphics calls go here. This is called after Tick
        //Graphics.DrawText($"Plugin {GetType().Name} is working.", new Vector2(100, 100), Color.Red);
    }


    public override void EntityAdded(Entity entity)
    {
        //If you have a reason to process every entity only once,
        //this is a good place to do so.
        //You may want to use a queue and run the actual
        //processing (if any) inside the Tick method.
    }

    private void HighlightMapNode(AtlasNodeDescription mapNode, int Count, Color color)
    {
        var radius = (Count * 5) + (mapNode.Element.GetClientRect().Right - mapNode.Element.GetClientRect().Left) / 2;
        Graphics.DrawCircle(mapNode.Element.GetClientRect().Center, radius, color, 4, 16);
    }

    private void DrawLineToMapNode(AtlasNodeDescription mapNode, AtlasNodeDescription fromNode, Color color)
    {
        Graphics.DrawLine(fromNode.Element.GetClientRect().Center, mapNode.Element.GetClientRect().Center, 4.0f, color);
    }

    private void DrawMapName(AtlasNodeDescription mapNode)
    {
        DrawTextWithBackground(mapNode.Element.Area.Name.ToUpper(), mapNode.Element.GetClientRect().Center, Settings.Graphics.FontColor, Settings.Graphics.BackgroundColor, true, 10, 3);
    }
    private Vector2 DrawTextWithBackground(string text, Vector2 position, Color color, Color backgroundColor, bool center = false, int xPadding = 0, int yPadding = 0)
    {
        var boxSize = Graphics.MeasureText(text);

        boxSize += new Vector2(xPadding, yPadding);    

        if (center)
            position = position - new Vector2(boxSize.X / 2, boxSize.Y / 2);

        Graphics.DrawBox(position, boxSize + position, backgroundColor, 5.0f);        

        // Pad text position
        position += new Vector2(xPadding / 2, yPadding / 2);

        Graphics.DrawText(text, position, color);
        return boxSize;
    }
}
