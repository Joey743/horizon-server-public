using RT.Common;
using Server.Common;

namespace RT.Models
{
    [MediusMessage(NetMessageClass.MessageClassLobby, MediusLobbyMessageIds.GetLadderStats)]
    public class MediusGetLadderStatsRequest : BaseLobbyMessage, IMediusRequest
    {
        public override byte PacketType => (byte)MediusLobbyMessageIds.GetLadderStats;

        public MessageId MessageID { get; set; }

        public int AccountID_or_ClanID;
        public MediusLadderType LadderType;

        public override void Deserialize(Server.Common.Stream.MessageReader reader)
        {
            // 
            base.Deserialize(reader);

            //
            MessageID = reader.Read<MessageId>();

            // 
            AccountID_or_ClanID = reader.ReadInt32();
        }

        public override void Serialize(Server.Common.Stream.MessageWriter writer)
        {
            // 
            base.Serialize(writer);

            writer.Write(MessageID ?? MessageId.Empty);

            //
            writer.Write(AccountID_or_ClanID);
        }

        public override string ToString()
        {
            return base.ToString() + " " +
                $"MessageID: {MessageID} " +
                $"AccountID_or_ClanID: {AccountID_or_ClanID} " +
                $"LadderType: {LadderType}";
        }
    }
}