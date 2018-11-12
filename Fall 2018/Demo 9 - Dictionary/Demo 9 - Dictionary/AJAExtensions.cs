using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Demo_9___Dictionary;

namespace aja
{
    static class AJAExtensions
    {
        public enum MemoryScale { b = 1, kb = 1024 * b, mb = 1024 * kb, gb = 1024 * mb }
        public static String MemorySizeString(this long size, MemoryScale ms)
            => $"{((double)size / (int)ms):N2} {Enum.GetName(typeof(MemoryScale), ms)}";

        //Variant below returns shortest possibility
        //Yes, I know there are much simpler ways to do this
        //Overly fancy for demonstration purposes
        public static String MemorySizeString(this long size)
         => (size < 100) ? $"{size} b" : //Treat small values as a special case
            (((MemoryScale[])Enum.GetValues(typeof(MemoryScale))).ToList() //List of all scales
            .Select(ms => MemorySizeString(size, ms))) //generated list of size strings (kb, mb, gb)
            .TakeWhile(s => s.First() != '0') //Eliminate leading zeros
            .TakeWhile(s => s.Count(c => Char.IsDigit(c)) > 2) //Eliminate imprecise values
            .Aggregate((currshortest, next) =>
                next.Length < currshortest.Length ? next : currshortest); //Get the shortest
        //The aggregate above is quite baroque syntax for finding the shortest, but again for demo
        //That said: .Sort(s=>s.Length).First() will also work, but I have an allergy against sorting
        //a list just to find the shortest (linear search is much faster). This is a four element list,
        //so it really doesn't matter.

        public static String Description(this DirData dd)
        => $"{new DirectoryInfo(dd.Directory).Name}"
                + $" ({dd.DirectoryCount} dirs, {dd.FileCount} files, "
                + $" {MemorySizeString(dd.StorageSize)})";

        public static String Description<TK, TV>(this KeyValuePair<DirectoryInfo, DirData> kvp)
        => $"{kvp.Key} - {kvp.Value.Description()}";

        public static ListViewItem LVIFromKVP(this KeyValuePair<DirectoryInfo, DirData> kvp)
            => new ListViewItem(new[]{kvp.Key.ToString(), //Array literals!
                kvp.Value.DirectoryCount.ToString(),
                kvp.Value.FileCount.ToString(),
                MemorySizeString(kvp.Value.StorageSize)});

        //Compare Methods (Note that DirectoryInfo doesn't come with it's own, so..

        public static int CompareTo(this DirectoryInfo me, DirectoryInfo you)
        {
            return me.FullName.CompareTo(you.FullName);
        }

        public static int CompareTo<TK, TV>
            (KeyValuePair<DirectoryInfo, DirData> me,
            KeyValuePair<DirectoryInfo, DirData> you)
        {
            return me.Value == you.Value ?
                me.Value.StorageSize.CompareTo(you.Value.StorageSize)
                : me.Key.CompareTo(you.Key);
        }
    }

}
