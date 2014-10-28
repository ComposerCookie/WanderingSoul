using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;

namespace Lost_Soul
{
    public class Sprite
    {
        string _path;
        bool _loaded;
        int _type;
        Texture _texture;

        public Sprite(string name)
        {
            _path = name;
            _type = 0;
            _texture = new Texture(name);
            _loaded = (_texture == null) ? false : true;
        }

        public Sprite(string name, int type)
        {
            _path = name;
            _type = type;
            _texture = new Texture(name);
            _loaded = (_texture == null) ? false : true;
        }

        public bool ReloadTexture()
        {
            _texture = new Texture(_path);
            _loaded = (_texture == null) ? false : true;
            return _loaded;
        }

        public bool ReloadTexture(string path)
        {
            _texture = new Texture(path);
            _path = path;
            _loaded = (_texture == null) ? false : true;
            return _loaded;
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Texture Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
