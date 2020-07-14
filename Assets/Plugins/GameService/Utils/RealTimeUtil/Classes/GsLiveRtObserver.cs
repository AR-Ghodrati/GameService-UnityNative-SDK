// <copyright file="GsLiveRtObserver.cs" company="Firoozeh Technology LTD">
// Copyright (C) 2020 Firoozeh Technology LTD. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>


/**
* @author Alireza Ghodrati
*/


using System.Collections.Generic;
using System.Linq;
using FiroozehGameService.Models;
using Plugins.GameService.Utils.GSLiveRT.Classes.Abstracts;
using Plugins.GameService.Utils.GSLiveRT.Classes.Attributes;
using Plugins.GameService.Utils.GSLiveRT.Consts;
using Plugins.GameService.Utils.GSLiveRT.Utils;
using UnityEngine;

namespace Plugins.GameService.Utils.GSLiveRT.Classes
{
    public class GsLiveRtObserver : MonoBehaviour
    {
        
        [Header("Set a unique ID to send data from this observer.")]
        public byte id;
        
        [Header("Add Your Components that You Want To Observe And Serializable")]
        public List<GsLiveSerializable> serializableComponents;


        private void OnEnable()
        {
            if (serializableComponents?.Count > Sizes.MaxId)
                throw new GameServiceException("observableComponents Count is Too Large!");
            
            // register Observer
            ObjectUtil.RegisterObserver(this);
        }

        private void FixedUpdate()
        {
            if (serializableComponents == null) return;
            byte idCounter = 0;
            foreach (var component in serializableComponents)
            {
                component.Id = idCounter++;
                SenderUtil.NetworkObserver(id,component);
            }
        }

        internal void ApplyData(byte componentId,byte[] data)
        {
            var currentComponent = serializableComponents.Find(sc => sc.Id == componentId);
            if(currentComponent == null)
                throw new GameServiceException("Cant Apply Data , Because Component With This id Not Found");
            
            currentComponent.Deserialize(data);
        }
    }
}