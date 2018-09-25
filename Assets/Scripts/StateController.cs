using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum state { invalid, empty, blue, purple, green, orange, yellow, red };

    public state[,] States = new state[17, 13]  // Each cell's state on the board. Changes depending on how many players (PlayerPref "PlayerAmount").
{
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.purple, state.purple, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.purple, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.invalid },
        {state.invalid, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.invalid },
        {state.invalid, state.orange, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.yellow },
        {state.orange, state.orange, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.yellow, state.yellow },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid }
    };
}
