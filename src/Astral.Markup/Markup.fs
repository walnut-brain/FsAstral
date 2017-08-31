namespace Astral
open System

type IEvent<'t> = interface end
type ICall<'t> = interface end
type ICall<'req, 'resp> = interface end

type IKeyProvider = 
    abstract Key : string

[<AttributeUsage(AttributeTargets.Class, Inherited = false)>]
type ContractAttribute(name : string) =
    inherit Attribute()
    member __.Name = name

[<AttributeUsage(AttributeTargets.Class, Inherited = false)>]
type ServiceAttribute(name : string) =
    inherit Attribute()
    member __.Name = name

[<AttributeUsage(AttributeTargets.Class, Inherited = false)>]
type VersionAttribute(version : string) =
    inherit Attribute()
    member __.Version = Version.Parse(version)
    
[<AttributeUsage(AttributeTargets.Class, Inherited = false)>]
type EndpointAttribute(name : string) =
    inherit Attribute()
    member __.Name = name


