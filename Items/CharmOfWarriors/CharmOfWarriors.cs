﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Combinations.Items.CharmOfWarriors
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class CharmOfWarriors : CombinationsBaseModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Slowly regenerates life\n" +
                "Reduces the cooldown of healing potions by 25%\n" +
                "5% increased melee damage");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 22;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 5);
            Item.rare = ItemRarityID.LightPurple;
            Item.stack = 1;
            Item.lifeRegen = 2;
            Item.defense = 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<CharmOfEndurance.CharmOfEndurance>();
            recipe.AddIngredient(ItemID.Ruby, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.pStone = true;
            player.GetDamage(DamageClass.Melee) += 0.05f;
        }

        public static int ItemType() => ModContent.ItemType<CharmOfWarriors>();

        public override List<int> IncompatibleAccessories() => new List<int>()
        {
            ItemType(),
            CharmOfEndurance.CharmOfEndurance.ItemType(),
            CharmOfRangers.CharmOfRangers.ItemType(),
            CharmOfSummoning.CharmOfSummoning.ItemType(),
            CharmOfThrowing.CharmOfThrowing.ItemType(),
            CharmOfWizards.CharmOfWizards.ItemType(),
        };
    }
}
