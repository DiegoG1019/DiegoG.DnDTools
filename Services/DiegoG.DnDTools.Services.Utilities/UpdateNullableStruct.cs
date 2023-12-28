namespace DiegoG.DnDTools.Services.Utilities;

public readonly record struct UpdateNullableStruct<T>(T? Value) where T : struct;
