using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_SONY_CHECKSUM
{
    public class CrestronModuleClass_SONY_CHECKSUM : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.StringInput FROM_SMPL__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE__DOLLAR__;
        object FROM_SMPL__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 70;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SEMAPHORE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 72;
                    _SplusNVRAM.SEMAPHORE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 74;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u00A9" , FROM_SMPL__DOLLAR__ ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 76;
                        _SplusNVRAM.TEMP__DOLLAR__  .UpdateValue ( Functions.Mid ( FROM_SMPL__DOLLAR__ ,  (int) ( 2 ) ,  (int) ( 5 ) )  ) ; 
                        __context__.SourceCodeLine = 77;
                        _SplusNVRAM.CHECKSUM = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 78;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( _SplusNVRAM.TEMP__DOLLAR__ ); 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 80;
                            _SplusNVRAM.CHECKSUM = (ushort) ( (_SplusNVRAM.CHECKSUM | Byte( _SplusNVRAM.TEMP__DOLLAR__ , (int)( _SplusNVRAM.I ) )) ) ; 
                            __context__.SourceCodeLine = 78;
                            } 
                        
                        __context__.SourceCodeLine = 82;
                        TO_DEVICE__DOLLAR__  .UpdateValue ( FROM_SMPL__DOLLAR__ + Functions.Chr (  (int) ( _SplusNVRAM.CHECKSUM ) ) + "\u009A"  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 85;
                    _SplusNVRAM.SEMAPHORE = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 113;
            _SplusNVRAM.SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 114;
            Functions.ClearBuffer ( FROM_SMPL__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 115;
            Functions.ClearBuffer ( _SplusNVRAM.TEMP__DOLLAR__ ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.TEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        FROM_SMPL__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FROM_SMPL__DOLLAR____AnalogSerialInput__, 10, this );
        m_StringInputList.Add( FROM_SMPL__DOLLAR____AnalogSerialInput__, FROM_SMPL__DOLLAR__ );
        
        TO_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TO_DEVICE__DOLLAR____AnalogSerialOutput__, TO_DEVICE__DOLLAR__ );
        
        
        FROM_SMPL__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_SMPL__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_SONY_CHECKSUM ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FROM_SMPL__DOLLAR____AnalogSerialInput__ = 0;
    const uint TO_DEVICE__DOLLAR____AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort SEMAPHORE = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort CHECKSUM = 0;
            [SplusStructAttribute(3, false, true)]
            public CrestronString TEMP__DOLLAR__;
            
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
