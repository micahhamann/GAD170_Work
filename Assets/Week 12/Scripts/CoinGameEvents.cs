using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD170.WeekTwelve
{
    public static class CoinGameEvents
    {

        public delegate void NoParamsVoidDelegate();
        // so the T, is a generic component, what that means is that it could be anything, we have to define it when we use it
        public delegate void OneParamVoidDelegate<T1>(T1 paramOne);
        public delegate void TwoParamVoidDelegate<T1, T2>(T1 paramOne, T2 paramTwo);
        public delegate void ThreeParamVoidDelegate<T1, T2, T3>(T1 paramOne, T2 paramTwo, T3 paramThree);

        public static NoParamsVoidDelegate GameCompletedEvent;
        public static NoParamsVoidDelegate GameOverEvent;
        public static OneParamVoidDelegate<int> ChangeCoinAmountEvent;
        public static OneParamVoidDelegate<int> UpdatePlayerCoinValueEvent;
        public static OneParamVoidDelegate<int> UpdateDoorCoinValueEvent;
        public static OneParamVoidDelegate<Coin> OnCoinSpawnedEvent;
        public static OneParamVoidDelegate<Coin> OnCoinDespawnedEvent;

    }
}
