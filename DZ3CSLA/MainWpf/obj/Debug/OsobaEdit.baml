   M S B A M L   `   `   `  ����E  AProjektWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UpravljanjeProjektimaUpravljanjeProjektima  5      K GCsla, Version=3.6.0.0, Culture=neutral, PublicKeyToken=93be5fdc093e4c301$clr-namespace:Csla.Wpf;assembly=CslaCsla.Wpf 5      R NProjekt.Bll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=30ab9c75db8e6db1R8clr-namespace:UpravljanjeProjektima;assembly=Projekt.BllUpravljanjeProjektima 5      %    UpravljanjeProjektima.OsobaEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local#clr-namespace:UpravljanjeProjektima     5      5csla$clr-namespace:Csla.Wpf;assembly=Csla     5      Iproj8clr-namespace:UpravljanjeProjektima;assembly=Projekt.Bll     5        � 	Resources  5         Csla.Wpf.IdentityConverter   IdentityConverter  Csla.Wpf.CslaDataProvider  	UlogeList   
ObjectType%  UpravljanjeProjektima.UlogaList   FactoryMethod   IsAsynchronous 	 Osoba!  UpravljanjeProjektima.Osoba,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled   ManageObjectLifetime  Csla.Wpf.ObjectStatus  OsobaStatus � DataContext��%�   &	        &	      &	 R     &	 �     7    5      6%     5	      "  5
      $	 Get��5       .  5        5      -   5        "  5      $	 Get��5       .   .   . 5        5      8   5      5       J� CommandBindings 5   
   )  #System.Windows.Input.CommandBinding  5      -   5           Command$ ApplicationCommands.Open��5      5      .��5   
   � -   5        $��MainGrid��5       6   �� 	 �� Source#	 [   5        
lbTemplate
 �� Orientation  
LinkButton �� Path �� DisplayMemberPath �� SelectedValuePath �� SelectedValue �� BindsDirectlyToSource  lbroTemplate��%�  &	       7  7  7  &	 �    7  7  �� 5      .R�5       � .+�5!      �� $
 
Horizontal=�6%   .+�5"      �� 8��  $��0q�5#      $	��200��6    $��ApplicationCommands.Open��5$      
����  ���5%      �� $ SifProjekta���5&      �� $ NazProjekta�6<   �� 5'      $	��100��6P   ��6(   �� $ DatDodjeleUloge�6P   �� 5(      $ Value��5*      $	 Key��5+      $	��150��5-      ��5)      �� 8	   5,      �� $ IdUloge�5-      �� 5.      $
��Left=�6   $ ��ApplicationCommands.Delete��5/      $��Obriši��52      ��50      �� 8	  $ CommandManager� . ��51      �� 52      53      54      55      �� 56      .R�57      � .+�58      �� $
 
Horizontal=�6%   .+�59      �� 8��  $��0q�5:      $	��200��6    $��ApplicationCommands.Open��5;      
����  ���5<      �� $ 
IdProjekta���5=      �� $ NazProjekta�6:   �� 5>      $	��100��6N   ��6(   �� $ DatDodjeleUloge�6N   �� 5?      $ Value��5A      $	 Key��5B      $	��150��5D      {�.  ��5@      �� 8	   5C      �� $ IdUloge�5E      5F      5G      5H      5I      .+�5K        Csla.Wpf.Authorizer  -   5        $��	AuthPanel��5K      ._�5L      �� $��LeftToRight=�6   $��0 0 20 0q�69   .+�5M      �� $
 
Horizontal=�6!   .+�5N      ��   HeaderTextBlock#��[ 6$   Osoba6T   	  Csla.Wpf.BusyAnimation	  5O      -   5        $
��Busy��5O   -   $��20��69   $��20��6E   $��5q�6P    	  	IsRunning 5P      �� #	 [ $ IsBusy� . 5Q      �� 5R      Id:6%   �� 5S      ��6    �� *	IdOsobe+ �� Mode$ OneWay=�6H   �� 5T      Ime:6&   �� 5U      ��6   �� *
ImeOsobe+ �� 	Converter# [   �� ValidatesOnDataErrors . 6�   �� 5V      
Prezime:6*   �� 5W      ��6   �� *PrezimeOsobe+# [   . 6�   �� 5X      OIB:6&   �� 5Y      ��6   �� *OIB+# [   . 6   �� 5[      	Projekti:6'   �� 5\      -   5        $��ProjektListBox��5\      #��[ 5^      ��5]      �� *ProjektiOsobe+5^      �� 5_      $
 
Horizontal=�6!   .+�5`      �� $��ApplicationCommands.Save��5a      $
��Left=�5c       �� 	IsDefault . ��5b      �� #	 [ $ CommandManager� . .��5c   ;   Spremi6C   �� 5d      $��ApplicationCommands.Undo��5e      $
��Left=�5g       �� IsCancel . ��5f      �� #	 [ $ CommandManager� . .��5g   :   
Odustani6D   �� 5h      -   5        $
��Left=�5j      {�5h   !   �� #	 [ $ CanEditObject�.��5j   .   Dodaj65   5k      5l      5m      5n      5o      