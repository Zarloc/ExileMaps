using System.Drawing;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;


namespace ExileMaps;

public class ExileMapsSettings : ISettings
{
    //Mandatory setting to allow enabling/disabling your plugin
    public ToggleNode Enable { get; set; } = new ToggleNode(false);

    // Feature settings
    public FeatureSettings Features { get; set; } = new FeatureSettings();

    // Highlight settings
    public HighlightSettings Highlights { get; set; } = new HighlightSettings();

    // Graphic settings
    public GraphicSettings Graphics { get; set; } = new GraphicSettings();

}

    [Submenu(CollapsedByDefault = false)]
    public class FeatureSettings
    {
        [Menu("Apply to Incomplete Maps", "Features will apply to all accessible and incomplete map nodes.")]
        public ToggleNode UnlockedNodes { get; set; } = new ToggleNode(true);

        [ConditionalDisplay(nameof(UnlockedNodes))]
        [Menu("Draw Names for unlocked nodes", "Names will be drawn on the Atlas for unlocked map nodes.")]
        public ToggleNode UnlockedNames { get; set; } = new ToggleNode(true);

        [Menu("Apply to Locked Maps", "Features will apply to all inaccessible map nodes.")]
        public ToggleNode LockedNodes { get; set; } = new ToggleNode(true);

        [ConditionalDisplay(nameof(LockedNodes))]
        [Menu("Draw Names for Locked nodes", "Names will be drawn on the Atlas for locked map nodes.")]
        public ToggleNode LockedNames { get; set; } = new ToggleNode(true);

        [Menu("Apply to Unrevealed Maps", "Features will apply to all unrevealed map nodes.")]
        public ToggleNode UnrevealedNodes { get; set; } = new ToggleNode(true);
        
        [ConditionalDisplay(nameof(UnrevealedNodes))]
        [Menu("Draw Icons for Unrevealed Maps", "Icons will be drawn on the Atlas for unrevealed maps.")]
        public ToggleNode UnrevealedIcons { get; set; } = new ToggleNode(true);
        [ConditionalDisplay(nameof(UnrevealedNodes))]
        [Menu("Draw Names for Unrevealed Maps", "Names will be drawn on the Atlas for unrevealed maps.")]
        public ToggleNode UnrevealedNames { get; set; } = new ToggleNode(true);

        [Menu("Debug Mode", "Show node addresses on Atlas map")]
        public ToggleNode DebugMode { get; set; } = new ToggleNode(false);
    }

    [Submenu(CollapsedByDefault = false)]
    public class HighlightSettings
        {
        [Menu("Highlight Breaches", "Highlight breaches with a ring on the Atlas")]
        public ToggleNode HighlightBreaches { get; set; } = new ToggleNode(true);

        [Menu("Highlight Delirium", "Highlight delirium with a ring on the Atlas")]
        public ToggleNode HighlightDelirium { get; set; } = new ToggleNode(true);

        [Menu("Highlight Expedition", "Highlight expeditions with a ring on the Atlas")]
        public ToggleNode HighlightExpedition { get; set; } = new ToggleNode(true);

        [Menu("Highlight Rituals", "Highlight rituals with a ring on the Atlas")]
        public ToggleNode HighlightRitual { get; set; } = new ToggleNode(true);

        [Menu("Highlight Bosses", "Highlight rituals with a ring on the Atlas")]
        public ToggleNode HighlightBosses { get; set; } = new ToggleNode(true);

        [Menu("Highlight Untainted Paradise Maps", "Highlight untainted paradise with a ring on the Atlas")]
        public ToggleNode HighlightUntaintedParadise { get; set; } = new ToggleNode(true);

        [ConditionalDisplay(nameof(HighlightUntaintedParadise))]
        [Menu("Draw Lines to Untainted Paradise", "Draw lines from the Ziggurat to incomplete Untained Paradise maps on the Atlas")]
        public ToggleNode LineToParadise { get; set; } = new ToggleNode(false);

        [Menu("Highlight Trader Maps", "Highlight traders with a ring on the Atlas")]
        public ToggleNode HighlightTrader { get; set; } = new ToggleNode(true);

        [ConditionalDisplay(nameof(HighlightTrader))]
        [Menu("Draw Lines to Traders", "Draw lines to from the Ziggurat incomplete traders on the Atlas")]
        public ToggleNode LineToTrader { get; set; } = new ToggleNode(false);

        [Menu("Highlight Citadels", "Highlight citadels with a ring on the Atlas")]
        public ToggleNode HighlightCitadel { get; set; } = new ToggleNode(true);

        [ConditionalDisplay(nameof(HighlightCitadel))]
        [Menu("Draw Lines to Citadels", "Draw lines from the Ziggurat to incomplete citadels on the Atlas")]
        public ToggleNode LineToCitadel { get; set; } = new ToggleNode(false);
    }

    [Submenu(CollapsedByDefault = false)]
    public class GraphicSettings
    {
        [Menu("Font Color", "Color of the text on the Atlas")]
        public ColorNode FontColor { get; set; } = new ColorNode(Color.White);

        [Menu("Background Color", "Color of the background on the Atlas")]
        public ColorNode BackgroundColor { get; set; } = new ColorNode(Color.FromArgb(100, 0, 0, 0));

        [Menu("Breach Color", "Color of the ring around breaches on the Atlas")]
        public ColorNode breachColor { get; set; } = new ColorNode(Color.FromArgb(200, 143, 82, 246));

        [Menu("Delirium Color", "Color of the ring around delirium on the Atlas")]
        public ColorNode deliriumColor { get; set; } = new ColorNode(Color.FromArgb(200, 200, 200, 200));

        [Menu("Expedition Color", "Color of the ring around expeditions on the Atlas")]
        public ColorNode expeditionColor { get; set; } = new ColorNode(Color.FromArgb(200, 101, 129, 172));

        [Menu("Ritual Color", "Color of the ring around rituals on the Atlas")]
        public ColorNode ritualColor { get; set; } = new ColorNode(Color.FromArgb(200, 252, 3, 3));

        [Menu("Boss Color", "Color of the ring around bosses on the Atlas")]
        public ColorNode bossColor { get; set; } = new ColorNode(Color.FromArgb(200, 195, 156, 105));

        [Menu("Untainted Paradise Color", "Color of the ring around untainted paradise on the Atlas")]
        public ColorNode untaintedParadiseColor { get; set; } = new ColorNode(Color.FromArgb(200, 50, 200, 50));

        [Menu("Trader Color", "Color of the ring around traders on the Atlas")]
        public ColorNode traderColor { get; set; } = new ColorNode(Color.FromArgb(100, 0, 0, 0));

        [Menu("Citadel Color", "Color of the ring around citadels on the Atlas")]
        public ColorNode citadelColor { get; set; } = new ColorNode(Color.FromArgb(100, 0, 0, 0));

    }


