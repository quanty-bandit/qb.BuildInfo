# qb.BuildInfo

Components for build version management

## CONTENT

**BuildInfo**
Scripable object singleton class.
Provides build and environment metadata for the application, including version, build number, environment type, and build date. 
Intended for use in managing and accessing build-related information within the Unity project.

> Remaks
> This class is implemented as a ScriptableObject singleton and is typically used to centralize build information for deployment, diagnostics, or environment-specific configuration. 
> The build information is set at design time and is read-only at runtime. 
> For editor-only operations, such as updating the build number or environment, use the provided editor methods.
> Thread safety is not guaranteed; access and modification should occur on the main thread within the Unity Editor.


**EnvBuildEntries<T>**
Represents a collection of environment-specific entries, each associated with a build environment, allowing access to values based on the current build configuration.

> Remarks
> This class is useful for managing values that vary between different build environments, such as development, staging, or production. The current value is determined by the active environment specified in the associated BuildInfo. Typically used in scenarios where environment-dependent configuration or resources are required.

  
**EnvBuildData<T>**
Provides an abstract base class for storing environment-specific build data as a Unity ScriptableObject.
> Remarks
> This class is intended to be inherited to define strongly-typed build data for different environments, such as development, staging, or production.
> The data is typically configured in the Unity Editor and used at runtime to access environment-specific settings or resources.


**String_EBD**
Represents an environment build data that stores a string value.
> Remarks
> Use this class to define and manage string-based configuration or metadata within the environment build system. This type must be created as a Unity asset in editor workflows but not at runtime!

**StringArray_EBD**
Represents an environment build data that stores a string aray values.  
> Remarks
> Use this class to define and manage string-based configuration or metadata within the environment build system. This type must be created as a Unity asset in editor workflows but not at runtime!

  
## HOW TO INSTALL

Use the Unity package manager and the Install package from git url option.

- Install at first time,if you haven't already done so previously, the package <mark>[unity-package-manager-utilities](https://github.com/sandolkakos/unity-package-manager-utilities.git)</mark> from the following url: 
  [GitHub - sandolkakos/unity-package-manager-utilities: That package contains a utility that makes it possible to resolve Git Dependencies inside custom packages installed in your Unity project via UPM - Unity Package Manager.](https://github.com/sandolkakos/unity-package-manager-utilities.git)

- Next, install the package from the current package git URL. 
  
  All other dependencies of the package should be installed automatically.

## Dependencies

https://github.com/quanty-bandit/qb.Pattern.git
