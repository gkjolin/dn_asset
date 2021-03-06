/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#include "XEntityStatistics.h"

XEntityStatistics::XEntityStatistics(void)
{
	name = UNITY_STREAM_PATH + "Table/XEntityStatistics.bytes";
	ReadTable();
}

void XEntityStatistics::ReadTable()
{
	Open(name.c_str());
	long long filesize =0;
	int lineCnt = 0;
	Read(&filesize);
	Read(&lineCnt);
	m_data.clear();
	for(int i=0;i<lineCnt;i++)
	{
		XEntityStatisticsRow *row = new XEntityStatisticsRow();
		
		Read(&(row->uid));
		ReadString(row->name);
		Read(&(row->presentid));
		Read(&(row->type));
		ReadString(row->tag);
		Read(&(row->fightgroup));
		ReadString(row->summongroup);
		Read(&(row->walkspeed));
		Read(&(row->runspeed));
		ReadArray<float>(row->floatheight);
		Read(&(row->rotatespeed));
		Read(&(row->attackspeed));
		Read(&(row->skillcd));
		Read(&(row->attackprob));
		Read(&(row->sight));
		Read(&(row->fighttogetherdis));
		ReadString(row->belocked);
		ReadString(row->inbornbuff);
		ReadString(row->maxsuperarmor);
		Read(&(row->weakstatus));
		ReadString(row->superarmorbrokenbuff);
		Read(&(row->superarmorrecoveryvalue));
		Read(&(row->superarmorrecoverymax));
		Read(&(row->attackbase));
		Read(&(row->magicattackbase));
		Read(&(row->maxhp));
		Read(&(row->mobaexp));
		Read(&(row->mobaexprange));
		Read(&(row->mobakillneedhint));
		Read(&(row->posindex));
		Read(&(row->hpsection));
		Read(&(row->iswander));
		Read(&(row->block));
		Read(&(row->dynamicblock));
		Read(&(row->usinggeneralcutscene));
		Read(&(row->soloshow));
		Read(&(row->endshow));
		Read(&(row->fov));
		Read(&(row->aistarttime));
		Read(&(row->aiactiongap));
		Read(&(row->isfixedincd));
		Read(&(row->fashiontemplate));
		Read(&(row->highlight));
		ReadString(row->usemymesh);
		ReadString(row->extrareward);
		Read(&(row->aihit));
		ReadString(row->aibehavior);
		Read(&(row->initenmity));
		Read(&(row->alwayshpbar));
		Read(&(row->hidename));
		Read(&(row->ratioleft));
		Read(&(row->ratioright));
		Read(&(row->ratioidle));
		Read(&(row->ratiodistance));
		Read(&(row->ratioskill));
		Read(&(row->ratioexp));
		ReadString(row->navigation);
		Read(&(row->isnavpingpong));
		Read(&(row->hideinminimap));
		ReadString(row->access);
		ReadString(row->samebillboard);
		ReadString(row->pandoradropids);
		ReadString(row->dropids);
		ReadString(row->bigmeleepoints);
		m_data.push_back(row);
		m_map.insert(std::make_pair(row->uid, row));
	}
	this->Close();
}

void XEntityStatistics::GetRow(int idx,XEntityStatisticsRow* row)
{
	size_t len = m_data.size();
	if(idx<(int)len)
	{
		*row = *m_data[idx];
	}
	else
	{
		LOG("eror, XEntityStatistics index out of range, size: "+tostring(len)+" idx: "+tostring(idx));
	}
}

void XEntityStatistics::GetByUID(uint idx, XEntityStatisticsRow* row)
{
	if (m_map.find(idx) != m_map.end())
	{
		*row = *m_map[idx];
	}
}

int XEntityStatistics::GetLength()
{
	return (int)m_data.size();
}


extern "C"
{
	XEntityStatistics *xentitystatistics;

	int iGetXEntityStatisticsLength()
	{
		if(xentitystatistics==NULL)
		{
			xentitystatistics = new XEntityStatistics();
		}
		return xentitystatistics->GetLength();
	}

	void iGetXEntityStatisticsRow(int id,XEntityStatisticsRow* row)
	{
		if(xentitystatistics==NULL)
		{
			xentitystatistics = new XEntityStatistics();
		}
		xentitystatistics->GetRow(id,row);
	}

	void iGetXEntityStatisticsRowByID(uint id, XEntityStatisticsRow* row)
	{
		if (xentitystatistics == NULL)
		{
		   xentitystatistics = new XEntityStatistics();
		}
		xentitystatistics->GetByUID(id, row);
	}
}