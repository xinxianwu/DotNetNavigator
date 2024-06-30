﻿using System.Runtime.InteropServices;
using System.Text;

namespace EverythingSharp
{
    public abstract class EverythingBase
    {
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern int Everything_SetSearch(string lpSearchString);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetMatchPath(bool bEnable);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetMatchCase(bool bEnable);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetMatchWholeWord(bool bEnable);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetRegex(bool bEnable);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetMax(uint dwMax);
        [DllImport("Everything.dll")]
        public static extern void Everything_SetOffset(uint dwOffset);

        [DllImport("Everything.dll")]
        public static extern bool Everything_GetMatchPath();
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetMatchCase();
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetMatchWholeWord();
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetRegex();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetMax();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetOffset();
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetSearch();
        [DllImport("Everything.dll")]
        public static extern int Everything_GetLastError();

        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern bool Everything_Query(bool bWait);

        [DllImport("Everything.dll")]
        public static extern void Everything_SortResultsByPath();

        [DllImport("Everything.dll")]
        public static extern uint Everything_GetNumFileResults();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetNumFolderResults();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetNumResults();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetTotFileResults();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetTotFolderResults();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetTotResults();
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsVolumeResult(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsFolderResult(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsFileResult(uint nIndex);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern void Everything_GetResultFullPathName(uint nIndex, StringBuilder lpString, uint nMaxCount);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultPath(uint nIndex);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultFileName(uint nIndex);

        [DllImport("Everything.dll")]
        public static extern void Everything_Reset();
        /// <summary>
        ///  Resets the result list and search state, freeing any allocated memory by the library.
        /// </summary>
        /// <remarks>
        /// You should call Everything_CleanUp to free any memory allocated by the Everything SDK.
        /// Calling <see cref="Everything_SetSearch"/> frees the old search and allocates the new search string.
        /// Calling <see cref="Everything_Query"/> frees the old result list and allocates the new result list.
        /// </remarks>
        [DllImport("Everything.dll")]
        public static extern void Everything_CleanUp();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetMajorVersion();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetMinorVersion();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetRevision();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetBuildNumber();
        [DllImport("Everything.dll")]
        public static extern bool Everything_Exit();
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsDBLoaded();
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsAdmin();
        [DllImport("Everything.dll")]
        public static extern bool Everything_IsAppData();
        [DllImport("Everything.dll")]
        public static extern bool Everything_RebuildDB();
        [DllImport("Everything.dll")]
        public static extern bool Everything_UpdateAllFolderIndexes();
        [DllImport("Everything.dll")]
        public static extern bool Everything_SaveDB();
        [DllImport("Everything.dll")]
        public static extern bool Everything_SaveRunHistory();
        [DllImport("Everything.dll")]
        public static extern bool Everything_DeleteRunHistory();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetTargetMachine();

        // Everything 1.4
        [DllImport("Everything.dll")]
        public static extern void Everything_SetSort(uint dwSortType);
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetSort();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetResultListSort();
        [DllImport("Everything.dll")]
        public static extern void Everything_SetRequestFlags(uint dwRequestFlags);
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetRequestFlags();
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetResultListRequestFlags();
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultExtension(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultSize(uint nIndex, out long lpFileSize);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultDateCreated(uint nIndex, out long lpFileTime);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultDateModified(uint nIndex, out long lpFileTime);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultDateAccessed(uint nIndex, out long lpFileTime);
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetResultAttributes(uint nIndex);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultFileListFileName(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetResultRunCount(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultDateRun(uint nIndex, out long lpFileTime);
        [DllImport("Everything.dll")]
        public static extern bool Everything_GetResultDateRecentlyChanged(uint nIndex, out long lpFileTime);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultHighlightedFileName(uint nIndex);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultHighlightedPath(uint nIndex);
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        public static extern string Everything_GetResultHighlightedFullPathAndFileName(uint nIndex);
        [DllImport("Everything.dll")]
        public static extern uint Everything_GetRunCountFromFileName(string lpFileName);
        [DllImport("Everything.dll")]
        public static extern bool Everything_SetRunCountFromFileName(string lpFileName, uint dwRunCount);
        [DllImport("Everything.dll")]
        public static extern uint Everything_IncRunCountFromFileName(string lpFileName);

        [DllImport("Everything.dll")]
        public static extern bool Everything_IsFileInfoIndexed(uint fileInfoType);
    }
}
