﻿using Fantome.League.Helpers.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantome.League.IO.SKN
{
    public class SKNVertex
    {
        private bool IsTangent { get; set; }
        public Vector3 Position { get; private set; }
        public Vector4Byte BoneIndices { get; private set; }
        public Vector4 Weights { get; private set; }
        public Vector3 Normal { get; private set; }
        public Vector2 UV { get; private set; }
        public Vector4Byte Tangent { get; private set; }
        public SKNVertex(BinaryReader br, bool IsTangent)
        {
            this.Position = new Vector3(br);
            this.BoneIndices = new Vector4Byte(br);
            this.Weights = new Vector4(br);
            this.Normal = new Vector3(br);
            this.UV = new Vector2(br);
            if (IsTangent)
            {
                this.Tangent = new Vector4Byte(br);
                this.IsTangent = IsTangent;
            }

        }
        public void Write(BinaryWriter bw)
        {
            this.Position.Write(bw);
            this.BoneIndices.Write(bw);
            this.Weights.Write(bw);
            this.Normal.Write(bw);
            this.UV.Write(bw);
            if (this.IsTangent)
                this.Tangent.Write(bw);
        }
    }
}
