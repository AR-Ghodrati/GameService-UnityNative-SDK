// <copyright file="Types.cs" company="Firoozeh Technology LTD">
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


namespace Plugins.GameService.Utils.GSLiveRT.Consts
{

    internal enum Internals : byte
    {
        Padding = 0x0
    }
    internal enum Types : byte
    {
        ObserverActions = 0x0,
        ObjectsActions = 0x2,
        RunFunction = 0x3
    }

    internal enum ObjectActions : byte
    {
        Instantiate = 0x0,
        Destroy = 0x1
    }
}