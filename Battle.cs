using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURPSBot
{
    class Battle
    {
        // TODO: Create parties of monsters to encounter.
        private List<Entity> turnOrder = new List<Entity>();

        public void Fight()
        {
            while (turnOrder.Count > 1)
            {
                foreach (Entity e in turnOrder)
                {
                    if (e is PlayerCharacter)
                    {
                        Entity target = TargetMonster();
                        if (e.EquippedMainHand is Items.Equipment.Empty)
                        {
                            e.UnarmedAttack(target, TargetBodyPart(target));
                        }
                        else
                        {
                            e.EquippedMainHand.BattleAction(e, target);
                        }
                        if (target.CurrentHitPoints <= target.MaxHitPoints)
                        {
                            // Monster dies
                            target.Die(e);
                            turnOrder.Remove(target);
                        }
                    }
                    else if (e is Monster)
                    {
                        PlayerCharacter target = TargetPlayer();
                        e.EquippedMainHand.BattleAction(e, target);

                        if (target.CurrentHitPoints <= target.MaxHitPoints)
                        {
                            // Player dies
                            target.Die(e);
                            return;
                        }
                    }
                }
            }
            TargetPlayer().Wins += 1;
            return;
        }

        private Entity TargetMonster()
        {
            Random rng = new Random();
            Entity target = turnOrder[rng.Next(turnOrder.Count) - 1];
            while (!(target is Monster))
            {
                target = turnOrder[rng.Next(turnOrder.Count) - 1];
            }
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
        private PlayerCharacter TargetPlayer()
        {
            return turnOrder.OfType<PlayerCharacter>().First();
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
            turnOrder.Add(pc);
            turnOrder.AddRange(MonsterParty());
            turnOrder.Sort((a, b) =>
            {
                return a.Speed.CompareTo(b.Speed);
            });
            turnOrder.Reverse();
        }
    }
}