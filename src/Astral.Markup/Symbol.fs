namespace Astral
open System
open System.Collections.Generic;

[<AbstractClass>]
type Fact<'t>(value) =
    member __.Value = value
    member private __.Equals (o : Fact<'t>) =
        EqualityComparer<'t>.Default.Equals(value, o.Value)
    override __.Equals (o : obj) =
        if obj.ReferenceEquals(null, o) 
        then false
        else
            if obj.ReferenceEquals(__, o) 
            then true
            else 
                if o.GetType() <> __.GetType() then false
                else __.Equals(o :?> Fact<'t>);
    override __.GetHashCode () =
        EqualityComparer<'t>.Default.GetHashCode(__.Value);

type IPredicate<'t> = 
    abstract True : 't -> struct (bool * string)

type Fact<'t, 'pred> when 'pred : struct and 'pred :> IPredicate<'t> (value) =
    inherit Fact<'t>(value)
    do
        let struct (v, s) = Unchecked.defaultof<'pred>.True(value)
        if not v then 
            raise (ArgumentException (if (isNull s) then sprintf "%A not conform %A" value typeof<'pred> else s))
    
