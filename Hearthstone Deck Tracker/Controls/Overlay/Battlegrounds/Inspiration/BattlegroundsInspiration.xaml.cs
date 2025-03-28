﻿using System.Windows.Controls;
using System.Windows.Input;

namespace Hearthstone_Deck_Tracker.Controls.Overlay.Battlegrounds.Inspiration;

public partial class BattlegroundsInspiration : UserControl
{
	public BattlegroundsInspiration()
	{
		InitializeComponent();
	}

	private void BattlegroundsMinion_OnMouseDown(object sender, MouseButtonEventArgs e)
	{
		if(sender is not UserControl { DataContext: BattlegroundsMinionViewModel m })
			return;
		((BattlegroundsInspirationViewModel)DataContext).SetKeyMinion(m.Card);
		Core.Game.Metrics.BattlegroundsInspirationMinionClicks++;
	}

	private void HeroPower_OnMouseDown(object sender, MouseButtonEventArgs e)
	{
		if(sender is not UserControl { DataContext: HeroPowerViewModel h })
			return;
		((BattlegroundsInspirationViewModel)DataContext).SetKeyMinion(h.Card);
		Core.Game.Metrics.BattlegroundsInspirationMinionClicks++;
	}
}

