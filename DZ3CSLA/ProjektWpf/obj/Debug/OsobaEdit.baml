   M S B A M L   `   `   `  ����E  AProjektWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UpravljanjeProjektimaUpravljanjeProjektima  5      K GCsla, Version=3.6.0.0, Culture=neutral, PublicKeyToken=93be5fdc093e4c301$clr-namespace:Csla.Wpf;assembly=CslaCsla.Wpf 5      R NProjekt.Bll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=30ab9c75db8e6db1R8clr-namespace:UpravljanjeProjektima;assembly=Projekt.BllUpravljanjeProjektima 5      %    UpravljanjeProjektima.OsobaEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local#clr-namespace:UpravljanjeProjektima     5      5csla$clr-namespace:Csla.Wpf;assembly=Csla     5      Iproj8clr-namespace:UpravljanjeProjektima;assembly=Projekt.Bll     5        � 	Resources  5         Csla.Wpf.IdentityConverter   IdentityConverter  Csla.Wpf.CslaDataProvider  	UlogeList   
ObjectType%  UpravljanjeProjektima.UlogaList   FactoryMethod   IsAsynchronous 	 Osoba!  UpravljanjeProjektima.Osoba,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled   ManageObjectLifetime  Csla.Wpf.ObjectStatus  OsobaStatus � DataContext��%�   &	        &	      &	 R     &	 �     7    5      6%     5	      "  5
      $	 Get��5       .  5        5      -   5        "  5      $	 Get��5       .   .   . 5        5      8   5      5       J� CommandBindings 5   
   )  #System.Windows.Input.CommandBinding  5      -   5           Command$ ApplicationCommands.Open��5      5      .��5      �� $
��Auto=�6   $��1��66   .��5    
   � -   5        $��MainGrid��5        6   �� 	 �� Source#	 [   5!        
lbTemplate
 �� Orientation  
LinkButton �� Path �� DisplayMemberPath �� SelectedValuePath �� SelectedValue �� BindsDirectlyToSource  lbroTemplate��%�  &	       7  7  7  &	 �    7  7  �� 5"      .R�5#      � .+�5$      �� $
 
Horizontal=�6%   .+�5%      �� 8��  $��0q�5&      $	��200��6    $��ApplicationCommands.Open��5'      
����  ���5(      �� $ SifProjekta���5)      �� $ NazProjekta�6<   �� 5*      $	��100��6P   ��6(   �� $ DatDodjeleUloge�6P   �� 5+      $ Value��5-      $	 Key��5.      $	��150��50      ��5,      �� 8	   5/      �� $ IdUloge�50      �� 51      $
��Left=�6   $ ��ApplicationCommands.Delete��52      $��Obriši��55      ��53      �� 8	  $ CommandManager� . ��54      �� 55      56      57      58      �� 59      .R�5:      � .+�5;      �� $
 
Horizontal=�6%   .+�5<      �� 8��  $��0q�5=      $	��200��6    $��ApplicationCommands.Open��5>      
����  ���5?      �� $ 
IdProjekta���5@      �� $ NazProjekta�6:   �� 5A      $	��100��6N   ��6(   �� $ DatDodjeleUloge�6N   �� 5B      $ Value��5D      $	 Key��5E      $	��150��5G      {�.  ��5C      �� 8	   5F      �� $ IdUloge�5H      5I      5J      5K      5L      .+�5N        Csla.Wpf.Authorizer  -   5        $��	AuthPanel��5N      ._�5O      �� $��LeftToRight=�6   $��0 0 20 0q�69   .+�5P      �� $
 
Horizontal=�6!   .+�5Q      ��   HeaderTextBlock#��[ 6$   Osoba6T   	  Csla.Wpf.BusyAnimation	  5R      -   5        $
��Busy��5R   -   $��20��69   $��20��6E   $��5q�6P    	  	IsRunning 5S      �� #	 [ $ IsBusy� . 5T      �� 5U      Id:6%   �� 5V      ��6    �� *	IdOsobe+ �� Mode$ OneWay=�6H   �� 5W      Ime:6&   �� 5X      ��6   �� *
ImeOsobe+ �� 	Converter# [   �� ValidatesOnDataErrors . 6�   �� 5Y      
Prezime:6*   �� 5Z      ��6   �� *PrezimeOsobe+# [   . 6�   �� 5[      OIB:6&   �� 5\      ��6   �� *OIB+# [   . 6   �� 5^      	Projekti:6'   �� 5_      -   5        $��ProjektListBox��5_      #��[ 5a      ��5`      �� *ProjektiOsobe+5a      �� 5b      $
 
Horizontal=�6!   .+�5c      �� $��ApplicationCommands.Save��5d      $
��Left=�5f       �� 	IsDefault . ��5e      �� #	 [ $ CommandManager� . .��5f   ;   Spremi6C   �� 5g      $��ApplicationCommands.Undo��5h      $
��Left=�5j       �� IsCancel . ��5i      �� #	 [ $ CommandManager� . .��5j   :   
Odustani6D   �� 5k      -   5        $
��Left=�5m      {�5k   !   �� #	 [ $ CanEditObject�.��5m   .   Dodaj65   5n      5o      5p      5q      5s      5u      