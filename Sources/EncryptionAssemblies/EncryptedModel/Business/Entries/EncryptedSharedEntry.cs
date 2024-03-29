﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedModel.Business.Entries
{
    public class EncryptedSharedEntry : EncryptedEntry
    {
        public EncryptedSharedEntry(string encryptionType, string Uid, byte[] EncryptedLogin, byte[] EncryptedPassword, byte[] EncryptedApp, byte[] EncryptedNote)
            : base(encryptionType, Uid, EncryptedLogin, EncryptedPassword, EncryptedApp, EncryptedNote) { }
    }
}
