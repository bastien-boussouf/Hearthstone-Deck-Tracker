﻿using System.Collections.Generic;
using System.Linq;

namespace Hearthstone_Deck_Tracker.Hearthstone.RelatedCardsSystem.Cards.Paladin;

public class TyrsTears: ICardWithRelatedCards
{
	public string GetCardId() => HearthDb.CardIds.Collectible.Paladin.TyrsTears_TyrsTearsToken;

	public bool ShouldShowForOpponent(Player opponent) => false;

	public List<Card?> GetRelatedCards(Player player) =>
		player.DeadMinionsCards
			.Select(entity => CardUtils.GetProcessedCardFromEntity(entity, player))
			.Distinct()
			.Where(card => card != null && card.IsClass(player.CurrentClass))
			.OrderBy(card => card!.Cost)
			.ToList();
}

public class TyrsTearsForged: ICardWithRelatedCards
{
	public string GetCardId() => HearthDb.CardIds.NonCollectible.Paladin.TyrsTears;

	public bool ShouldShowForOpponent(Player opponent) => false;

	public List<Card?> GetRelatedCards(Player player) =>
		player.DeadMinionsCards
			.Select(entity => CardUtils.GetProcessedCardFromEntity(entity, player))
			.Distinct()
			.Where(card => card != null && card.IsClass(player.CurrentClass))
			.OrderBy(card => card!.Cost)
			.ToList();
}
