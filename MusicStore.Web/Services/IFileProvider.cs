using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.Services
{
    public interface IFileProvider
    {
        byte[] GetFileBytes(string relativePath);
    }
}
