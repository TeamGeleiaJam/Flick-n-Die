using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    #region Field Declarations
    private PlayerHand playerHand;
    private List<StatusEffectData> statusEffects;

    public List<StatusEffectData> StatusEffects { get => statusEffects; }
    #endregion

    #region MonoBehavior Controller
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    #endregion

    #region Public Functions
    public void AddStatusEffect(StatusEffectData statusEffect)
    {
        statusEffects.Add(statusEffect);
        RunEffectTicks(statusEffect);
    }
    #endregion

    #region Private Functions
    private IEnumerator RunEffectTicks(StatusEffectData statusEffect)
    {
        WaitForSeconds tickInterval = new WaitForSeconds(statusEffect.Duration / statusEffect.Ticks);

        for (int tick = 1; tick < statusEffect.Ticks; tick++)
        {
            foreach (EffectData effect in statusEffect.Effects)
            {
                // Applies damage
                playerHand.HurtController.CurrentHurt += (effect.Damage / statusEffect.Ticks);

                // Applies status effects
                if (effect.StatusEffectType != EEffectType.None)
                {
                    StartCoroutine(ManageStatusEffect(effect.StatusEffectType, effect.Intensity, statusEffect.Duration));
                }
            }

            yield return tickInterval;
        }

        statusEffects.Remove(statusEffect);
    }

    private IEnumerator ManageStatusEffect(EEffectType effectType, float modifierValue, float effectDuration)
    {
        ChangeModifier(effectType, modifierValue);
        yield return new WaitForSeconds(effectDuration);
        ChangeModifier(effectType, 1);
        yield break;
    }

    private void ChangeModifier(EEffectType effectType, float modifierValue)
    {
        switch (effectType)
                {
                    case EEffectType.None:
                    // Does nothing
                        break;
                    case EEffectType.DamageModifier:
                        // Changes the damage modifier
                        playerHand.HurtController.DamageModifier = modifierValue;
                        break;
                    case EEffectType.Slow:
                        // Changes speed modifier
                        playerHand.MotorController.SpeedModifier = modifierValue;
                        break;
                    case EEffectType.Weaken:
                        // Changes flick force modifier
                        playerHand.FlickController.FlickForceModifier = modifierValue;
                        break;
                    default:
                    // Does nothing
                        break;
                }
    }
    #endregion
}
