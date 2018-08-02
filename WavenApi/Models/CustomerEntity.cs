﻿using Microsoft.WindowsAzure.Storage.Table;

namespace WavenApi.Models
{
	public class CustomerEntity : TableEntity
	{
		public CustomerEntity(string lastName, string firstName)
		{
			this.PartitionKey = lastName;
			this.RowKey = firstName;
		}

		public CustomerEntity() { }

		public string Email { get; set; }
	}
}