using System;
using System.Collections.Generic;

using Xunit;
using BareKnuckleJson;

public class JsonTests{
	
	public class TestType
	{
		public int[] IntArray { get; set; }
		public double[] DoubleArray { get; set; }
		public string Name { get; set; }
	
		public TestType()
		{
		this.IntArray = new[] { 5, 6, 7 };
		this.DoubleArray = new[] { 1.4, 2.322, 5.43 };
		Name = "hello";
		}
	
	}
	
	public class StringJsonTests{
		
		
		public StringJsonTests(){
			
		}
		
		[Fact]
		public void SerialzeTest(){
			
			var ttl = new List<TestType>();

			var tt1 = new TestType();
			var tt2 = new TestType();
			var tt3 = new TestType();
			var tt4 = new TestType();
		
			ttl.Add(tt1);
			ttl.Add(tt2);
			ttl.Add(tt3);
			ttl.Add(tt4);
			
			var json = Json.Serialize(ttl);
			Console.WriteLine(json);
			
		}
	}
	
}