using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    class Battle
    {
        private List<Entity> turnOrder = new List<Entity>();
        DataManager dm = new DataManager();
        PlayerCharacter player;

        public void Fight()
        {
            do
            {
                foreach (Entity e in turnOrder.ToList())
                {
                    if (e is PlayerCharacter)
                    {
                        Entity target = TargetMonster();
                        e.BattleAction(target, TargetBodyPart(target));
                        if (target.CurrentHitPoints <= 0)
                        {
                            target.Die(player);
                            turnOrder.Remove(target);
                        }
                    }
                    else
                    {
                        e.BattleAction(player, TargetBodyPart(player));
                        if (player.CurrentHitPoints <= 0)
                        {
                            player.Die();
                            return;
                        }
                    }
                }
            }
            while (turnOrder.Count > 1);
            player.Wins++;
            dm.Save(player);
        }

        private Entity TargetMonster()
        {
            Random rng = new Random();
            Entity target;
            do
            {
                target = turnOrder[rng.Next(turnOrder.Count - 1)];
            }
            while (!(target is Monster));

            return target;
        }
        private Equipment TargetBodyPart(Entity e)
        {
            Random rng = new Random();
            int roll = rng.Next(1, 8);

            switch(roll)
            {
                case 1:
                    return e.EquippedHead;
                case 2:
                    return e.EquippedBody;
                case 3:
                    return e.EquippedArms;
                case 4:
                    return e.EquippedGloves;
                case 5:
                    return e.EquippedMainHand;
                case 6:
                    return e.EquippedOffHand;
                case 7:
                    return e.EquippedLegs;
                case 8:
                    return e.EquippedFeet;
            }
            return e.EquippedBody;
        }
        private List<Entity> MonsterParty()
        {
            Random rng = new Random();
            List<Entity> mList;

            switch (rng.Next(6))
            {
                default:
                case 0:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.GiantRat()
                        };
                        break;
                    }
                case 1:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.GiantRat(), new Monsters.GiantRat(), new Monsters.GiantRat()
                        };
                        break;
                    }
                case 2:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.DireWolf()
                        };
                        break;
                    }
                case 3:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.DireWolf(), new Monsters.DireWolf(), new Monsters.DireWolf()
                        };
                        break;
                    }
                case 4:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.Unicorn()
                        };
                        break;
                    }
                case 5:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.Zombie()
                        };
                        break;
                    }
                case 6:
                    {
                        mList = new List<Entity>()
                        {
                            new Monsters.Zombie(), new Monsters.Zombie(), new Monsters.Zombie()
                        };
                        break;
                    }
            }
            return mList;
        }

        public Battle(PlayerCharacter pc)
        {
            player = pc;
            player.CurrentHitPoints = player.MaxHitPoints;
            turnOrder.Add(player);
            turnOrder.AddRange(MonsterParty());
            turnOrder.Sort((a, b) =>
            {
                return a.Speed.CompareTo(b.Speed);
            });
            turnOrder.Reverse();
        }
    }
}