﻿using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using WavenApi.Services.NewFolder;

namespace WavenApi.Models
{
	[DataContract]
	public partial class ResponseSuccess : IEquatable<ResponseSuccess>, IResponseApi
	{
		/// <summary>
		/// Gets or Sets Success
		/// </summary>
		[DataMember(Name = "success")]
		public bool? Success { get; set; }

		public string SuccessMessage { get; set; }
		/// <summary>
		/// Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("class ResponseSuccess {\n");
			sb.Append("  Success: ").Append(Success).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}

		/// <summary>
		/// Returns the JSON string presentation of the object
		/// </summary>
		/// <returns>JSON string presentation of the object</returns>
		public string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}

		/// <summary>
		/// Returns true if objects are equal
		/// </summary>
		/// <param name="obj">Object to be compared</param>
		/// <returns>Boolean</returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((ResponseSuccess)obj);
		}

		/// <summary>
		/// Returns true if ResponseSuccess instances are equal
		/// </summary>
		/// <param name="other">Instance of ResponseSuccess to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(ResponseSuccess other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					Success == other.Success ||
					Success != null &&
					Success.Equals(other.Success)
				);
		}

		/// <summary>
		/// Gets the hash code
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				var hashCode = 41;
				// Suitable nullity checks etc, of course :)
				if (Success != null)
					hashCode = hashCode * 59 + Success.GetHashCode();
				return hashCode;
			}
		}

		#region Operators
#pragma warning disable 1591

		public static bool operator ==(ResponseSuccess left, ResponseSuccess right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ResponseSuccess left, ResponseSuccess right)
		{
			return !Equals(left, right);
		}

#pragma warning restore 1591
		#endregion Operators
	}
}