using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    public interface ILoader<Key, Value> { Dictionary<Key, Value> CreateDictionary(); }
}

