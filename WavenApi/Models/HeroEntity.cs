using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace WavenApi.Models
{
    public class HeroEntity : TableEntity
	{
	    public HeroEntity(string partition, string row)
	    {
		    this.PartitionKey = partition;
		    this.RowKey = row;
	    }

	    public HeroEntity() { }

	    public string Name { get; set; }
	}
}
