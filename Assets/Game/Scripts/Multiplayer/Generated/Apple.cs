// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.46
// 

using Colyseus.Schema;

public partial class Apple : Schema {
	[Type(0, "uint32")]
	public uint id = default(uint);

	[Type(1, "ref", typeof(Vector2Float))]
	public Vector2Float position = new Vector2Float();
}

