// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the GNU Affero General Public License, Version 3.0.
// Commercial licenses available at http://imageresizing.net/
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Imazen.DiskCache {
    internal class AsyncWrite {

        public AsyncWrite(AsyncWriteCollection parent, MemoryStream data, string physicalPath, string key) {
            this.Parent = parent;
            this._data = data;
            this.PhysicalPath = physicalPath;
            this.Key = key;
            this.JobCreatedAt = DateTime.UtcNow;
        }

      
        public AsyncWriteCollection Parent {get; private set;}
        
        public string PhysicalPath { get; private set; }

        public string Key { get; private set; }
        /// <summary>
        /// Returns the UTC time this AsyncWrite object was created.
        /// </summary>
        public DateTime JobCreatedAt { get; private set; }



        private readonly MemoryStream _data;

        /// <summary>
        /// Returns the length of the Data
        /// </summary>
        /// <returns></returns>
        public long GetDataLength() {
            return _data.Length;
        }
        /// <summary>
        /// Returns the length of the buffer capacity
        /// </summary>
        /// <returns></returns>
        public long GetBufferLength() {
            return _data.Capacity;
        }

        /// <summary>
        /// Wraps the data in a readonly MemoryStream so it can be accessed on another thread
        /// </summary>
        /// <returns></returns>
        public MemoryStream GetReadonlyStream() {
            //Wrap the original buffer in a new MemoryStream.
            return new MemoryStream(_data.GetBuffer(), 0, (int)_data.Length, false, true);
        }
    }
}
