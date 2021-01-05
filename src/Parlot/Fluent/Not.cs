﻿using System;

namespace Parlot.Fluent
{
    public sealed class Not<T> : Parser<T>
    {
        private readonly IParser<T> _parser;

        public Not(IParser<T> parser)
        {
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public override bool Parse(ParseContext context, ref ParseResult<T> result)
        {
            context.EnterParser(this);

            if (!_parser.Parse(context, ref result))
            {
                return true;
            }

            context.Scanner.Cursor.ResetPosition(result.Start);
            return false;
        }
    }
}