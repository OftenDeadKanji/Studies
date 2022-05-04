using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InterativeAreaController : MonoBehaviour
{
    [SerializeField]
    GameObject interactionTarget;
    IInteractive interaction;

    private void Awake()
    {
        if(interactionTarget == null)
        {
            throw new Exception("interactionTarget is null!");
        }
        else
        {
            interaction = interactionTarget.GetComponent<IInteractive>();
            if(interaction == null)
            {
                throw new Exception("IInteractive not found in interactionTarget!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero" && other.gameObject != interactionTarget)
        {
            var heroes = GameObject.FindGameObjectsWithTag("Hero");
            foreach(var hero in heroes)
            {
                if(hero == other.gameObject)
                {
                    var heroController = hero.GetComponent<HeroController>();
                    if(heroController != null)
                    {
                        var navMeshAgent = heroController.GetComponent<NavMeshAgent>();
                        navMeshAgent.destination = hero.transform.position;

                        this.gameObject.SetActive(false);

                        interaction.Interact(heroController);
                    }
                    break;
                }
            }
        }
    }
}
