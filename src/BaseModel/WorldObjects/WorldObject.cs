using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace BaseModel.WorldObjects
{
    public abstract class WorldObject
    {
        /// <summary>
        /// After inheriting from this object, you are expected to call validate() to ensure
        /// that an allowed objectType is given.
        /// </summary>
        protected abstract Type[] AllowedTypes { get; }

        internal WorldObject(Type type)
        {
            this._objectType = type;
        }

        /// <summary>
        /// @see AllowedTypes
        /// </summary>
        protected void validate()
        {
            ValidateType(this._objectType, AllowedTypes);
        }

        /// <summary>
        /// If a type is not found in the dictionary, then it is interpreted as the object 
        /// not being able to collide with other objects possessing this trait.
        /// </summary>
        public Dictionary<Type, List<Polygon>> PolygonDictionary { private get; set; }

        [JsonIgnore]
        public int ID { get; set; }

        /// <summary>
        /// If the object is able to collide with other object possessing the same trait,
        /// </summary>
        [JsonIgnore]
        public List<Polygon> Polygons
        {
            get
            {
                try
                {
                    return PolygonDictionary[this._objectType];
                } catch (KeyNotFoundException)
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public abstract Tag Tags { get; }

        [JsonProperty("x")]
        public int X { get; set; }
        [JsonProperty("y")]
        public int Y { get; set; }
        [JsonIgnore]
        public int ZIndex { get; set; }

        [JsonProperty("m11")]
        public float Transformation_m11;
        [JsonProperty("m12")]
        public float Transformation_m12;
        [JsonProperty("m21")]
        public float Transformation_m21;
        [JsonProperty("m22")]
        public float Transformation_m22;

        // customState?     pl dictionary sajat mezoknek

        public static void ValidateType(Type type, Type[] allowedTypes)
        {
            foreach (Type t in allowedTypes)
            {
                if (t == type)
                {
                    return;
                }
            }

            throw new NotSupportedException();
        }

        private readonly Type _objectType;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Type ObjectType => _objectType;

        public enum Type
        {
            _2_CROSSROAD_1,
            _2_CROSSROAD_2,
            BICYCLE,
            BOUNDARY,
            CAR_1_BLUE,
            CAR_1_RED,
            CAR_1_WHITE,
            CAR_2_BLUE,
            CAR_2_RED,
            CAR_2_WHITE,
            CAR_3_BLACK,
            CIRCLE,
            CROSSWALK,
            GARAGE,
            MAN,
            PARKING_90,
            PARKING_BOLLARD,
            PARKING_SPACE_PARALLEL,
            ROADSIGN_PARKING_RIGHT,
            ROADSIGN_PRIORITY_STOP,
            ROADSIGN_SPEED_40,
            ROADSIGN_SPEED_50,
            ROADSIGN_SPEED_60,
            ROAD_2LANE_45LEFT,
            ROAD_2LANE_45RIGHT,
            ROAD_2LANE_6LEFT,
            ROAD_2LANE_6RIGHT,
            ROAD_2LANE_90LEFT,
            ROAD_2LANE_90RIGHT,
            ROAD_2LANE_ROTARY,
            ROAD_2LANE_STRAIGHT,
            ROAD_2LANE_TJUNCTIONLEFT,
            ROAD_2LANE_TJUNCTIONRIGHT,
            TREE,
            WOMAN,
        }
        
        [Flags]
        public enum Tag
        {
            NONE = 0,
            DYNAMIC = 1,
            BUILDING = 2,
            ROAD_OBSTACLE = 4,
            ROAD = 8,
            SIGN = 16,
            ROAD_SIGN = 32,
            NATURE = 64,
            VEHICLE = 128,
            PEDESTRIAN = 256
        }
    }
}
