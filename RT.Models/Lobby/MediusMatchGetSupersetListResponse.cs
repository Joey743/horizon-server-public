using RT.Common;
using Server.Common;

namespace RT.Models
{
    /// <summary>
    /// Response returning a list of Match Supersets from the database
    /// </summary>
    [MediusMessage(NetMessageClass.MessageClassLobbyExt, MediusLobbyExtMessageIds.MatchGetSupersetListResponse)]
    public class MediusMatchGetSupersetListResponse : BaseLobbyExtMessage, IMediusRequest
    {

        public override byte PacketType => (byte)MediusLobbyExtMessageIds.MatchGetSupersetListResponse;

        /// <summary>
        /// Message ID
        /// </summary>
        public MessageId MessageID { get; set; }
        /// <summary>
        /// Response code to fetching superset list
        /// </summary>
        public MediusCallbackStatus StatusCode;
        /// <summary>
        /// End of List flag
        /// </summary>
        public bool EndOfList;
        /// <summary>
        /// Superset ID
        /// </summary>
        public long SupersetID;
        /// <summary>
        /// Superset Name
        /// </summary>
        public string SupersetName;
        /// <summary>
        /// Superset Description
        /// </summary>
        public string SupersetDescription;
        /// <summary>
        /// Superset ExtraInfo
        /// </summary>
        public string SupersetExtraInfo;

        public override void Deserialize(Server.Common.Stream.MessageReader reader)
        {
            // 
            base.Deserialize(reader);

            //
            MessageID = reader.Read<MessageId>();

            //reader.ReadBytes(3);
			
            //
            StatusCode = reader.Read<MediusCallbackStatus>();
            EndOfList = reader.Read<bool>();

            //reader.ReadBytes(3);

            //
            SupersetID = reader.ReadInt32();
            SupersetName = reader.ReadString(Constants.SUPERSETNAME_MAXLEN);
            SupersetDescription = reader.ReadString(Constants.SUPERSETDESCRIPTION_MAXLEN);
            SupersetExtraInfo = reader.ReadString(Constants.SUPERSETEXTRAINFO_MAXLEN);

            //reader.ReadBytes(2);
        }

        public override void Serialize(Server.Common.Stream.MessageWriter writer)
        {
            // 
            base.Serialize(writer);

            //
            writer.Write(MessageID ?? MessageId.Empty);

            //writer.Write(new byte[3]);

            // 
            writer.Write(StatusCode);
            writer.Write(EndOfList);

            //writer.Write(new byte[3]);


            //
            writer.Write(SupersetID);
            writer.Write(SupersetName, Constants.SUPERSETNAME_MAXLEN);
            writer.Write(SupersetDescription, Constants.SUPERSETDESCRIPTION_MAXLEN);
            writer.Write(SupersetExtraInfo, Constants.SUPERSETEXTRAINFO_MAXLEN);

            //writer.Write(new byte[2]);

        }

        public override string ToString()
        {
            return base.ToString() + " " +
                $"MessageID: {MessageID} " +
                $"StatusCode: {StatusCode} " +
                $"SupersetID: {SupersetID} " +
                $"SupersetName: {SupersetName} " +
                $"SupersetDescription: {SupersetDescription} " +
                $"SupersetExtraInfo: {SupersetExtraInfo} " +
                $"EndOfList: {EndOfList}";
        }
    }
}
