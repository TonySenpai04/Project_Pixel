using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Tony.Projectile;
using UnityEngine;
using Tony.Skill;
using Tony.Player;
using Tony.Item;
using Tony.Pet;

namespace Tony.Enemy
{

    public class TrunkController : EnemyControllerBase
    {

        public List<SkillData.SkillSet> skillSets;
        [SerializeField] private string petReceivedId;

        public override void Start()
        {
            base.Start();
            projectileSpawn = new EnemySpawnProjectile(this.projectile, this.projectilePool, this.projectilePos);
        }

        [Obsolete]
        public override void HandlePlayerFound()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, ((IATKR)enemy.Atk).GetATKR());

            if (collider2Ds.Length > 0)
            {
                bool playerFound = false;

                foreach (var item in collider2Ds)
                {
                    var player = item.GetComponent<PlayerControllerBase>();
                    if (player != null)
                    {
                        this.player = player;
                        playerFound = true;
                        break;
                    }
                }

                if (playerFound)
                {
                    if (player != null && player.Stats.HitPoint.GetCurrentHealth() > 0)
                    {

                        Attack();
                        //Skill1();
                        //Skill2();
                        //Skill3();
                    }
                }
                else
                {
                    player = null;
                }
            }
            else
            {
                player = null;
            }
        }

        public override void Skill1()
        {
            SetSkillAttribute();
            skillController.Skill1(this.skillSets[0].currentSkillAttributes);

        }

        public override void Skill2()
        {
            SetSkillAttribute();
            skillController.Skill2(this.skillSets[1].currentSkillAttributes);

        }

        public override void Skill3()
        {
            SetSkillAttribute();
            skillController.Skill3(this.skillSets[2].currentSkillAttributes);
        }
        public void SetSkillAttribute()
        {
            int skill1 = enemy.GetCurrentData().LevelSkill1;
            int skill2 = enemy.GetCurrentData().LevelSkill2;
            int skill3 = enemy.GetCurrentData().LevelSkill3;

            skillSets[0].SetCurrentSkillAttributes(skillSets[0].attributes[skill1]);
            skillSets[1].SetCurrentSkillAttributes(skillSets[1].attributes[skill2]);
            skillSets[2].SetCurrentSkillAttributes(skillSets[2].attributes[skill3]);
            skillController.SetAbilityCooldown(skillSets[0].attributes[skill1].coolDown,
            skillSets[1].attributes[skill2].coolDown, skillSets[2].attributes[skill3].coolDown);

        }
        public override void OnDeath()
        {
            if (enemy.HitPoint.GetCurrentHealth() <= 0)
            {
                GetComponent<DropItem>().CreateItem(this.transform.position);
                PetBase pet = PetManager.instance.FindPetById(petReceivedId);
                if (PetManager.instance.PetSlotManager.petSlots.Count < 3)
                {
                    PetManager.instance.PetSlotManager.petSlots.Add(pet);
                    PetManager.instance.PetSlotManager.UpdateAllSlotButtons();
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}

