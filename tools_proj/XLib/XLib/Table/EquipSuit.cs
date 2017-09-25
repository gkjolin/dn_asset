//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.8784
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XTable {
    
    
    public class EquipSuit : CVSReader {
        
        public class RowData :BaseRow {
			public int SuitID;
			public string SuitName;
			public int Level;
			public int ProfID;
			public int SuitQuality;
			public bool IsCreateShow;
			public int[] EquipID;
			public string Effect1;
			public Sequence<uint> Effect2;
			public Sequence<uint> Effect3;
			public Sequence<uint> Effect4;
			public Sequence<uint> Effect5;
			public Sequence<uint> Effect6;
			public Sequence<uint> Effect7;
			public Sequence<uint> Effect8;
			public Sequence<uint> Effect9;
			public Sequence<uint> Effect10;
		}


		public RowData[] Table;

		public override string bytePath { get { return "Table/EquipSuit"; } }
        
        // 二分法查找
        public virtual RowData GetByUID(int id) {
			return BinarySearch(Table, 0, Table.Length - 1, id) as RowData;
        }
        
        public override void OnClear(int lineCount) {
			if (lineCount > 0) Table = new RowData[lineCount];
			else Table = null;
        }
        
        public override void ReadLine(System.IO.BinaryReader reader) {
			RowData row = new RowData();
			Read<int>(reader, ref row.SuitID, intParse); columnno = 0;
			Read<string>(reader, ref row.SuitName, stringParse); columnno = 1;
			Read<int>(reader, ref row.Level, intParse); columnno = 2;
			Read<int>(reader, ref row.ProfID, intParse); columnno = 3;
			Read<int>(reader, ref row.SuitQuality, intParse); columnno = 4;
			Read<bool>(reader, ref row.IsCreateShow, boolParse); columnno = 5;
			ReadArray<int>(reader, ref row.EquipID, intParse); columnno = 6;
			Read<string>(reader, ref row.Effect1, stringParse); columnno = 7;
			ReadSequence<uint>(reader, ref row.Effect2, uintParse); columnno = 8;
			ReadSequence<uint>(reader, ref row.Effect3, uintParse); columnno = 9;
			ReadSequence<uint>(reader, ref row.Effect4, uintParse); columnno = 10;
			ReadSequence<uint>(reader, ref row.Effect5, uintParse); columnno = 11;
			ReadSequence<uint>(reader, ref row.Effect6, uintParse); columnno = 12;
			ReadSequence<uint>(reader, ref row.Effect7, uintParse); columnno = 13;
			ReadSequence<uint>(reader, ref row.Effect8, uintParse); columnno = 14;
			ReadSequence<uint>(reader, ref row.Effect9, uintParse); columnno = 15;
			ReadSequence<uint>(reader, ref row.Effect10, uintParse); columnno = 16;
			row.sortID = (int)row.SuitID;
			Table[lineno] = row;
			columnno = -1;
        }
    }
}