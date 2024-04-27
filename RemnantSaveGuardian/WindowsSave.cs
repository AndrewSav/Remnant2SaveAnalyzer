﻿using System;
using System.Collections.Generic;
using System.IO;

namespace RemnantSaveGuardian
{
    class WindowsSave
    {
        public string Container { get; set; }
        public string Profile { get; set; }
        public List<string> Worlds { get; set; }
        private bool _isValid;
        public bool Valid { get { return _isValid; } }

        public WindowsSave(string containerPath)
        {
            Worlds = new List<string>();
            Container = containerPath;
            var folderPath = new FileInfo(containerPath).Directory.FullName;
            var offset = 136;
            byte[] byteBuffer = File.ReadAllBytes(Container);
            var profileBytes = new byte[16];
            Array.Copy(byteBuffer, offset, profileBytes, 0, 16);
            var profileGuid = new Guid(profileBytes);
            Profile = profileGuid.ToString().ToUpper().Replace("-", "");
            _isValid = File.Exists($@"{folderPath}\{Profile}");
            offset += 160;
            while (offset + 16 < byteBuffer.Length)
            {
                var worldBytes = new byte[16];
                Array.Copy(byteBuffer, offset, worldBytes, 0, 16);
                var worldGuid = new Guid(worldBytes);
                Worlds.Add(folderPath + "\\" + worldGuid.ToString().ToUpper().Replace("-", ""));
                offset += 160;
            }
        }
    }
}
