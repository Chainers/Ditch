// brush: "csharp" aliases: ["c-sharp", "c#"]

//  This file is part of the "jQuery.Syntax" project, and is distributed under the MIT License.
//  Copyright (c) 2011 Samuel G. D. Williams. <http://www.oriontransfer.co.nz>
//  See <jquery.syntax.js> for licensing details.

Syntax.register('csharp', function(brush) {
    var keywords = ["abstract", "add", "alias", "ascending", "base", "break", "case", "catch", "class", "const", "continue", "default", "delegate", "descending", "do", "dynamic", "else", "enum", "event", "explicit", "extern", "finally", "for", "foreach", "from", "get", "global", "goto", "group", "if", "implicit", "in", "interface", "into", "join", "let", "lock", "namespace", "new", "operator", "orderby", "out", "override", "params", "partial", "readonly", "ref", "remove", "return", "sealed", "select", "set", "stackalloc", "static", "struct", "switch", "throw", "try", "unsafe", "using", "value", "var", "virtual", "volatile", "where", "while", "yield"];
    
    var access = ["public", "private", "internal", "protected"];
    
    var types = ["object", "bool", "byte", "fixed", "float", "uint", "char", "ulong", "ushort", "decimal", "int", "sbyte", "short", "void", "long", "string", "double"];
    
    var operators = ["+", "-", "*", "/", "%", "&", "|", "^", "!", "~", "&&", "||", "++", "--", "<<", ">>", "==", "!=", "<", ">", "<=", ">=", "=", "?", "new", "as", "is", "sizeof", "typeof", "checked", "unchecked", "."];
    
    var values = ["this", "true", "false", "null"];
        
    brush.push(values, {klass: 'constant'});
    brush.push(types, {klass: 'type'});
    brush.push(keywords, {klass: 'keyword'});
    brush.push(operators, {klass: 'operator'});
    brush.push(access, {klass: 'access'});
    
    
    // Comments:
    brush.push(Syntax.lib.cStyleComment);
    brush.push(Syntax.lib.webLink);

    // Comments: // and ////
    brush.push({
        pattern: /(\/\/)([^\/].*)/g,
        klass: 'comment', 
        allow: ['href']
    });
    brush.push({
        pattern: /(\/\/\/\/)(.*)/g,
        klass: 'comment', 
        allow: ['href']
    });
    
    // Comments: xml Doc
    brush.push({
        pattern: /(\/\/\/)([^\/].*)/g,
        klass: 'xmlCommentSlash', 
        matches: Syntax.extractMatches({klass: 'xmlCommentSlash'}, {klass: 'xmlComment', allow:['xmlCommentTag']}),
    });/*
    brush.push({
        pattern: /(\/\/\/)(?!\/)([^\n\r<]*)(<[^>]+>)(.*)(<[^>]+>)+/g,
        klass: 'xmlCommentSlash', 
        matches: Syntax.extractMatches({klass: 'xmlCommentSlash'}, {klass: 'xmlComment', allow:['xmlCommentTag']}, {klass: 'xmlCommentTag'}, {klass: 'xmlComment'}, {klass: 'xmlCommentTag'}),
    });*/
    brush.push({
        pattern: /(?:<)([^>]+)(?:>)/g,
        matches: Syntax.extractMatches({klass: 'classIdentifier'}),
    });
    brush.push({
        pattern: /(<)([^>]+)(>)/g,
        matches: Syntax.extractMatches({klass: 'xmlCommentTag'}, {klass: 'xmlCommentTag'}, {klass: 'xmlCommentTag'}),
    });

    
    // Strings
    brush.push({
        pattern: /@(?=")/g,
        klass: 'string'
    });
    brush.push(Syntax.lib.singleQuotedString);
    brush.push(Syntax.lib.doubleQuotedString);
    brush.push(Syntax.lib.stringEscape);

    brush.push(Syntax.lib.decimalNumber);
    brush.push(Syntax.lib.hexNumber);   

    // Event decalration
    brush.push({
        pattern: /[\s]+event[\s]+([\S]+)[\s]+([a-zA-Z\<\>][a-zA-Z0-9_]+)/g,
        matches: Syntax.extractMatches({klass: 'classIdentifier', allow:['operator', 'type', 'namespaceIdentifier']}, {klass: 'eventIdentifier'})
    });
    
    // Functions
    brush.push({
        pattern: /(?:\.)([a-zA-Z_][a-z0-9_]+)/gi,
        matches: Syntax.extractMatches({klass: 'identifier'})
    });

    // Namespace
    brush.push({
        pattern: /[\s]+(?:namespace|using)[\s]+([\S]+)/g,
        matches: Syntax.extractMatches({klass: 'namespaceIdentifier', allow:['operator']})
    });

    // preprocessor
    brush.push({
        pattern: /(#[\S]+)[\s]*([\S]*)/g,
        matches: Syntax.extractMatches({klass: 'preprocessorInstruction'}, {klass: 'preprocessorArgument'})
    });
    
    
    
    
    
    
    
    
    // fields
    brush.push({
        pattern: /this(?:.([\S]+))/g,
        matches: Syntax.extractMatches({klass: 'classIdentifier', allow:['operator']})
    });     

    
    // Classes
    brush.push({
        pattern: /\b_*[A-Z][\w]*\b/g,
        klass: 'classIdentifier',
    });


    brush.push(Syntax.lib.cStyleFunction);

    brush.push({
        pattern: /([\S]+)\./g,
        matches: Syntax.extractMatches({klass: 'namespaceIdentifier', allow:['operator']})
    }); 
});
