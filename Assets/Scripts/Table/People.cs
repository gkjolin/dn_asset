//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XTable {
    using UnityEngine;
    using System.IO;
    
    
    public class People : CVSReader {
        
        public class RowData{
			public int id;
			public string name;
			public int age;
			public int[] part;
			public bool com;
		}

		public RowData[] Table = null;

		public string bytePath { get { return "Table/People"; } }
        
        public override void OnClear(int lineCount) {
			if (lineCount > 0) Table = new RowData[lineCount];
			else Table = null;
        }
        
        public override void ReadLine(System.IO.BinaryReader reader) {
			RowData row = new RowData();
			Read<int>(reader, ref row.id, intParse); columnno = 0;
			Read<string>(reader, ref row.name, stringParse); columnno = 1;
			Read<int>(reader, ref row.age, intParse); columnno = 2;
			ReadArray<int>(reader, ref row.part, intParse); columnno = 3;
			Read<bool>(reader, ref row.com, boolParse); columnno = 4;
			Table[lineno] = row;
			columnno = -1;
        }
    }
}
