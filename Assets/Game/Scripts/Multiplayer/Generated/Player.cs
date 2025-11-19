// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.46
// 

using Colyseus.Schema;

public partial class Player : Schema {
	[Type(0, "string")]
	public string nickname = default(string);

	[Type(1, "number")]
	public float speed = default(float);

	[Type(2, "uint16")]
	public ushort parts = default(ushort);

	[Type(3, "uint16")]
	public ushort score = default(ushort);

	[Type(4, "uint16")]
	public ushort color = default(ushort);

	[Type(5, "number")]
	public float pX = default(float);

	[Type(6, "number")]
	public float pZ = default(float);
}

