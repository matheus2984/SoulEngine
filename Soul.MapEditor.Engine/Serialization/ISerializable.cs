namespace Soul.MapEditor.Core.Serialization
{
    public interface ISerializable
    {
        void Serialize(BinaryOutput output);
        ISerializable Deserialize(BinaryInput input);
    }
}