namespace Soul.Engine.Serialization
{
    public interface ISerializable
    {
        void Serialize(BinaryOutput output);
        ISerializable Deserialize(BinaryInput input);
    }
}