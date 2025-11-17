// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.46
// 

using Colyseus.Schema;

public partial class Player : Schema {
	[Type(0, "number")]
	public float speed = default(float);

	[Type(1, "uint16")]
	public ushort p = default(ushort);

	[Type(2, "uint16")]
	public ushort c = default(ushort);

	[Type(3, "number")]
	public float pX = default(float);

	[Type(4, "number")]
	public float pZ = default(float);
}

