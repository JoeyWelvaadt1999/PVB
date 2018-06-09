using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class State : MonoBehaviour
    {
        public virtual void Enter()
        {

        }

        public virtual void Leave()
        {

        }

        public abstract void Act();
        public abstract void Reason();
    }
}
