﻿using ArmyOfCreatures.Logic.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;
using System.Globalization;

namespace ArmyOfCreatures.Extended
{
    public class NewBattleManager : BattleManager
    {
        private const string LogFormat = "--- {0} - {1}";

        private readonly ICollection<ICreaturesInBattle> firstArmyCreatures;

        private readonly ICollection<ICreaturesInBattle> secondArmyCreatures;

        //private readonly ICreaturesFactory creaturesFactory;

       // private readonly ILogger logger;
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;
        public NewBattleManager(ICreaturesFactory creaturesFactory, ILogger logger) : base(creaturesFactory, logger)
        {
            this.firstArmyCreatures = new List<ICreaturesInBattle>();
            this.secondArmyCreatures = new List<ICreaturesInBattle>();
            //this.creaturesFactory = creaturesFactory;
            //this.logger = logger;
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            if (creaturesInBattle == null)
            {
                throw new ArgumentNullException("creaturesInBattle");
            }

            if (creatureIdentifier.ArmyNumber == 1)
            {
                this.firstArmyCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 2)
            {
                this.secondArmyCreatures.Add(creaturesInBattle);
            }
            else if(creatureIdentifier.ArmyNumber == 3)
            {
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", creatureIdentifier.ArmyNumber));
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (identifier.ArmyNumber == 1)
            {
                return this.firstArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            if (identifier.ArmyNumber == 2)
            {
                return this.secondArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", identifier.ArmyNumber));
        }
    }
}
