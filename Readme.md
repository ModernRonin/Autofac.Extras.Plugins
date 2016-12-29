# Autofac.Extras.Plugins

*Makes it easy to create a plugin-based architecture with Autofac.*

## Motivation
Imagine you deploy an application with, say, a pipeline for transforming Maya binaries to some specific graphics-engine dependent format and another pipeline for transforming 3dsMax files to the same target format.
You have a whole lot of types which have to be differently implemented in both pipelines, even though they stick to the same contracts. And you are using Autofac. So you need a way to easily tell the container:
- this is a component to be used in the context of the Maya pipeline
- this is a component to be used in the context of the 3dsMax pipeline
- this component X should be used by all pipelines
- for the Maya pipeline, please override X with Y

If this scenario sounds familiar to you, this Autofac.Extra is for you.

## Usage
For detailed usage, see the ```src/Samples``` directory here at github.

A short overview though:

```
builder.RegisterType<GermanHelloWorld>().AsPlugin().Provide<IHelloWorld>("UniqueNameOfMyPlugin");
```
registers ```GermanHelloWorld``` as providing ```IHelloWorld``` in the context of *UniqueNameOfMyPlugin*.

```
builder.RegisterType<StandardFinisher>().AsPlugin().ProvideForAll<IFinisher>();
```
registers ```StandardFinisher``` as the default implementation of ```IFinisher``` for all plugins.

```
builder.RegisterType<GermanFinisher>().AsPlugin().Override<IFinisher>("UniqueNameOfMyOtherPlugin");
```
overrides the service ```IFinisher``` with ```GermanFinisher``` in the context of *UniqueNameOfMyOtherPlugin*.

## Scope Limitation
Sometimes you will want to load plugins dynamically, that is, upon deployment of the main application you do not yet know which plugins will be available. In such a case you will need to tell Autofac 
which assemblies to load. For example, load all assemblies in a ```Plugins``` folder somewhere in your local user data. This functionality is not part of this extra, however. 
If you need this additional bit, you might wanna take a look at https://github.com/DenisBiondic/Autofac.Extras.ModuleDiscovery. Please note, however, that I have no first-hand experience with that package.

## License
This package is governed by the [Apache 2.0](http://opensource.org/licenses/Apache-2.0) license.