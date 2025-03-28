using Hearthstone_Deck_Tracker.Utility.ValueMoments.Utility;
using Newtonsoft.Json;
using Hearthstone_Deck_Tracker.Utility.ValueMoments.Enums;
using HearthDb.Enums;

namespace Hearthstone_Deck_Tracker.Utility.ValueMoments.Actions.Action
{
	public abstract class VMBattlegroundsAction : VMEndMatchAction
	{
		public const string Tier7OverlayTrial = "Tier7Overlay";

		protected VMBattlegroundsAction(
			Franchise franchise, int? maxDailyOccurrences,
			int heroDbfId, string heroName, int finalPlacement, GameType gameType, int rating, GameMetrics gameMetrics
		) : base(franchise, null, maxDailyOccurrences)
		{
			HeroDbfId = heroDbfId;
			HeroName = heroName;
			FinalPlacement = finalPlacement;
			GameType = gameType;
			Rating = rating;
			Tier7HeroOverlayDisplayed = gameMetrics.Tier7HeroOverlayDisplayed;
			Tier7QuestOverlayDisplayed = gameMetrics.Tier7QuestOverlayDisplayed;
			Tier7TrinketOverlayDisplayed = gameMetrics.Tier7TrinketOverlayDisplayed;
			NumClickBattlegroundsMinionTiers = gameMetrics.BattlegroundsMinionTiersClicks;
			NumClickBattlegroundsMinionsByMinionTypeFilter = gameMetrics.BattlegroundsMinionsByMinionTypeFilterClicks;
			NumClickBattlegroundsMinionsInspiration = gameMetrics.BattlegroundsMinionsInspirationClicks;
			NumClickBattlegroundsInspirationToggle = gameMetrics.BattlegroundsInspirationToggleClicks;
			NumClickBattlegroundsInspirationMinion = gameMetrics.BattlegroundsInspirationMinionClicks;
			NumClickBattlegroundsCompGuides = gameMetrics.BattlegroundsCompGuidesClicks;
			NumClickBattlegroundsCompGuidesMinionHovers = gameMetrics.BattlegroundsCompGuidesMinionHovers;
			NumClickBattlegroundsCompsTab = gameMetrics.BattlegroundsCompsTabClicks;
			NumClickBattlegroundsHeroesTab = gameMetrics.BattlegroundsHeroesTabClicks;
			NumClickBattlegroundsCardsTab = gameMetrics.BattlegroundsCardsTabClicks;
			NumClickBattlegroundsCompGuidesInspiration = gameMetrics.BattlegroundsCompGuidesInspirationClicks;
			NumClickBattlegroundsBrowserTypeFilter = gameMetrics.BattlegroundsBrowserTypeFilterClicks;
			NumClickBattlegroundsBrowserMechanicFilter = gameMetrics.BattlegroundsBrowserMechanicFilterClicks;
			NumClickBattlegroundsBrowserOpenFilterPanel = gameMetrics.BattlegroundsBrowserOpenFilterPanelClicks;
			NumBobsBuddyTerminalCases = gameMetrics.BobsBuddyTerminalCases;
			if (gameMetrics.Tier7TrialActivated)
				TrialsActivated = new[] { Tier7OverlayTrial };
			if (gameMetrics.Tier7TrialsRemaining.HasValue)
				TrialsRemaining = new[] { $"{Tier7OverlayTrial}:{gameMetrics.Tier7TrialsRemaining}" };
			BattlegroundsSettings = new BattlegroundsSettings();
		}

		[JsonProperty("num_click_battlegrounds_browser_open_filter_panel")]
		public int NumClickBattlegroundsBrowserOpenFilterPanel { get; set; }

		[JsonProperty("num_click_battlegrounds_browser_mechanic_filter")]
		public int NumClickBattlegroundsBrowserMechanicFilter { get; set; }

		[JsonProperty("num_click_battlegrounds_browser_type_filter")]
		public int NumClickBattlegroundsBrowserTypeFilter { get; set; }

		[JsonProperty("hero_dbf_id")]
		public int HeroDbfId { get; }

		[JsonProperty("hero_name")]
		public string HeroName { get; }

		[JsonProperty("final_placement")]
		public int FinalPlacement { get; }

		[JsonProperty("game_type")]
		public GameType GameType { get; }

		[JsonProperty("battlegrounds_rating")]
		public int Rating { get; }

		[JsonIgnore]
		public bool Tier7HeroOverlayDisplayed { get; }

		[JsonIgnore]
		public bool Tier7QuestOverlayDisplayed { get; }

		[JsonIgnore]
		public bool Tier7TrinketOverlayDisplayed { get; }

		[JsonProperty("num_click_battlegrounds_minion_tiers")]
		public int NumClickBattlegroundsMinionTiers { get;  }

		[JsonProperty("num_click_battlegrounds_minions_by_minion_type_filter")]
		public int NumClickBattlegroundsMinionsByMinionTypeFilter { get;  }

		[JsonProperty("num_click_battlegrounds_minions_inspiration_button")]
		public int NumClickBattlegroundsMinionsInspiration { get; set; }

		[JsonProperty("num_click_battlegrounds_inspiration_overlay_toggle")]
		public int NumClickBattlegroundsInspirationToggle { get; set; }

		[JsonProperty("num_click_battlegrounds_inspiration_minion")]
		public int NumClickBattlegroundsInspirationMinion { get; set; }

		[JsonProperty("num_click_battlegrounds_comp_guides")]
		public int NumClickBattlegroundsCompGuides { get; set; }

		[JsonProperty("num_click_battlegrounds_comp_guides_minion_hovers")]
		public int NumClickBattlegroundsCompGuidesMinionHovers { get; set; }

		[JsonProperty("num_click_battlegrounds_comps_tab")]
		public int NumClickBattlegroundsCompsTab { get; set; }

		[JsonProperty("num_click_battlegrounds_heroes_tab")]
		public int NumClickBattlegroundsHeroesTab { get; set; }

		[JsonProperty("num_click_battlegrounds_cards_tab")]
		public int NumClickBattlegroundsCardsTab { get; set; }

		[JsonProperty("num_click_battlegrounds_comp_guides_inspiration")]
		public int NumClickBattlegroundsCompGuidesInspiration { get; set; }

		[JsonProperty("num_bobs_buddy_terminal_cases")]
		public int NumBobsBuddyTerminalCases { get;  }

		[JsonProperty("trials_activated", NullValueHandling = NullValueHandling.Ignore)]
		public string[]? TrialsActivated { get; }

		[JsonProperty("trials_remaining", NullValueHandling = NullValueHandling.Ignore)]
		public string[]? TrialsRemaining { get; }

		[JsonIgnore]
		public BattlegroundsSettings BattlegroundsSettings { get; }

		[JsonProperty("hdt_battlegrounds_settings_enabled")]
		[JsonConverter(typeof(VMEnabledSettingsJsonConverter))]
		protected BattlegroundsSettings BattlegroundsSettingsEnabled { get => BattlegroundsSettings; }

		[JsonProperty("hdt_battlegrounds_settings_disabled")]
		[JsonConverter(typeof(VMDisabledSettingsJsonConverter))]
		protected BattlegroundsSettings BattlegroundsSettingsDisabled { get => BattlegroundsSettings; }
	}
}
