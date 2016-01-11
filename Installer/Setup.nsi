!include LogicLib.nsh
!include MUI2.nsh
!include nsProcess.nsh

!define APPNAME "WTManager"

!define BASE_DIR        "..\WTManager\${TARG}"
!define EXE_FILE_NAME   "WTManager.exe"
!define PRIMARYASSEMBLY "${BASE_DIR}\${EXE_FILE_NAME}"

!tempfile VERSIONHEADER
!system 'nsisiw.exe -i "${PRIMARYASSEMBLY}" -o "${VERSIONHEADER}"'
!include /NONFATAL "${VERSIONHEADER}"

Name "${APPNAME} (${FILE_ARCHITECTURE})"

!if ${PLATFORM} == "x86"
    !define PROGDIR "$PROGRAMFILES"
    !define FRAMEWORKDIR "Framework"
!else
    !define PROGDIR "$PROGRAMFILES64"
    !define FRAMEWORKDIR "Framework64"
!endif

!define OUTDIR "Target"

# todo: find proper ngen location from in registry
!define NGEN_PATH "$WINDIR\Microsoft.NET\${FRAMEWORKDIR}\v4.0.30319\ngen.exe"

# Uninstall key
!define UNKEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"

# Version information
!ifdef VI_PRODUCTIONVERSION
    VIProductVersion "${VI_PRODUCTIONVERSION}"

    !ifdef VI_FILEVERSION
        VIAddVersionKey FileVersion "${VI_FILEVERSION}"
    !endif

    !ifdef VI_DESCRIPTION
        VIAddVersionKey FileDescription "${VI_DESCRIPTION}"
    !endif

    !ifdef VI_COPYRIGHTS
        VIAddVersionKey LegalCopyright "${VI_COPYRIGHTS}"
    !endif
!endif

!define MUI_COMPONENTSPAGE_NODESC

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_LANGUAGE "Russian"

Function .onInit
    !insertmacro MUI_LANGDLL_DISPLAY
    ReadRegStr $R0 HKLM \
        "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" \
        "UninstallString"
    StrCmp $R0 "" done

    MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
        "${APPNAME} is already installed. $\n$\nClick `OK` to remove the \
        previous version or `Cancel` to cancel this upgrade." \
        IDOK uninst
    Abort

    uninst:
        ClearErrors
        ExecWait '$R0'
        IfErrors no_remove_uninstaller done
    no_remove_uninstaller:
    done:
FunctionEnd

!system 'md "${OUTDIR}"'
OutFile "${OUTDIR}\setup-${VI_PRODUCTIONVERSION}-${FILE_ARCHITECTURE}.exe"

InstallDir "${PROGDIR}\${APPNAME}"
InstallDirRegKey HKLM "Software\${APPNAME}" "Install_Dir"
RequestExecutionLevel admin
ShowInstDetails show

# Program files section
Section "Program files"
    SectionIn RO
    SetOutPath $INSTDIR
    File /x *.pdb /x *.xml /x *.vshost.exe* "${BASE_DIR}\*.*"
    WriteRegStr   HKLM "${UNKEY}" "DisplayName"     "${APPNAME}"
    WriteRegStr   HKLM "${UNKEY}" "UninstallString" '"$INSTDIR\uninstall.exe"'
    WriteRegDWORD HKLM "${UNKEY}" "NoModify"         1
    WriteRegDWORD HKLM "${UNKEY}" "NoRepair"         1
    WriteUninstaller                                "uninstall.exe"
SectionEnd

# Run at startup section
Section "Run at startup (create scheduler task)"
    ExecWait '"$INSTDIR\${EXE_FILE_NAME}" /installtask'
SectionEnd

# NGEN installation section
Section "NGEN installation (faster startup)"
    AddSize 200
    nsExec::ExecToLog '${NGEN_PATH} install "$INSTDIR\${EXE_FILE_NAME}"'
SectionEnd

# Launch After Install section
Section "Launch after install"
    ExecShell "" "$INSTDIR\${EXE_FILE_NAME}"
SectionEnd

# Uninstall section
Section "Uninstall"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
    DeleteRegKey HKLM "SOFTWARE\${APPNAME}"
    nsExec::ExecToLog '"$INSTDIR\${EXE_FILE_NAME}" /removetask'
    ${nsProcess::CloseProcess} "${EXE_FILE_NAME}" $R0
    Delete "$INSTDIR\uninstall.exe"
    RMDir /r "$INSTDIR"
    ${nsProcess::Unload}
    nsExec::ExecToLog '${NGEN_PATH} uninstall ${APPNAME}'
SectionEnd