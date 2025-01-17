using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GridCellType {
    Empty,
    Solid,
    Glass,
    Outline,
    Filter,
    Dirt,
    Grass,
    Stone,
    Orange_Flowers,
    Thatch,
    Slate_Roof,
    Submerged_Sand,
    Beach_Sand,
    Volcanic_Rock,
    Cobblestone,
    Red_Brick,
    Regrown_Grass,
    Supported_Thatch,
    TYPE_MAX
}

[System.Serializable]
public struct GridCellData
{
    private const byte PROPERTY_NONE = 0;           // Indicates to render all sides
    private const byte PROPERTY_TRANSPARENT = 1;    // Indicates using alpha material and renders surrounding blocks
    private const byte PROPERTY_FULL_BLOCK = 2;     // Indicates to not render any faces between another full block

    public GridCellType type;
    public GridTexture texture;
    public Color color;

    public GridCellData(GridCellType type, GridTexture texture, Color color) {
        this.type = type;
        this.texture = texture;
        this.color = color;
    }

    public GridCellData(int type, Color color) {
        this.type = (GridCellType)type;
        this.texture = textures[type];
        this.color = color;
        if (this.type == GridCellType.Glass)
            this.color.a = 0.4f;
    }

    // By value of type
    private static readonly byte[] properties = new byte[]{
        PROPERTY_TRANSPARENT,                           // Empty
        PROPERTY_FULL_BLOCK,                            // Solid Block
        PROPERTY_TRANSPARENT | PROPERTY_FULL_BLOCK,     // Glass
        PROPERTY_FULL_BLOCK,                            // Outline
        PROPERTY_FULL_BLOCK,                            // Filter
        PROPERTY_FULL_BLOCK,                            //Dirt
        PROPERTY_FULL_BLOCK,                            //Grass
        PROPERTY_FULL_BLOCK,                            //Stone
        PROPERTY_FULL_BLOCK,                            //Orange_Flowers
        PROPERTY_FULL_BLOCK,                            //Thatch
        PROPERTY_FULL_BLOCK,                            //Slate_Roof
        PROPERTY_FULL_BLOCK,                            //Submerged_Snad
        PROPERTY_FULL_BLOCK,                            //Beach_Sand
        PROPERTY_FULL_BLOCK,                            //Volcanic_Rock
        PROPERTY_FULL_BLOCK,                            //Cobblestone
        PROPERTY_FULL_BLOCK,                            //Red_Brick
        PROPERTY_FULL_BLOCK,                            //Regrown_Grass
        PROPERTY_FULL_BLOCK,                            //Supported_Thatch
    };

    private static readonly GridTexture[] textures = new GridTexture[] {
        GridTexture.Default,
        GridTexture.Default,
        GridTexture.Default,
        GridTexture.Grid,
        GridTexture.Filter,
        GridTexture.Dirt,
        GridTexture.Grass,
        GridTexture.Stone,
        GridTexture.Orange_Flowers,
        GridTexture.Thatch,
        GridTexture.Slate_Roof,
        GridTexture.Submerged_Sand,
        GridTexture.Beach_Sand,
        GridTexture.Volcanic_Rock,
        GridTexture.Cobblestone,
        GridTexture.Red_Brick,
        GridTexture.Regrown_Grass,
        GridTexture.Supported_Thatch
    };

    public bool IsTransparent() => (properties[(int)type] & PROPERTY_TRANSPARENT) != 0;
    public bool IsFullBlock() => (properties[(int)type] & PROPERTY_FULL_BLOCK) != 0;
}
