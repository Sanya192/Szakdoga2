'use strict';

customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`
        <nav>
            <ul class="list">
                <li class="title">
                    <a href="index.html" data-type="index-link">angular documentation</a>
                </li>

                <li class="divider"></li>
                ${ isNormalMode ? `<div id="book-search-input" role="search"><input type="text" placeholder="Type to search"></div>` : '' }
                <li class="chapter">
                    <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
                    <ul class="links">
                        <li class="link">
                            <a href="overview.html" data-type="chapter-link">
                                <span class="icon ion-ios-keypad"></span>Overview
                            </a>
                        </li>
                        <li class="link">
                            <a href="index.html" data-type="chapter-link">
                                <span class="icon ion-ios-paper"></span>README
                            </a>
                        </li>
                                <li class="link">
                                    <a href="dependencies.html" data-type="chapter-link">
                                        <span class="icon ion-ios-list"></span>Dependencies
                                    </a>
                                </li>
                                <li class="link">
                                    <a href="properties.html" data-type="chapter-link">
                                        <span class="icon ion-ios-apps"></span>Properties
                                    </a>
                                </li>
                    </ul>
                </li>
                    <li class="chapter modules">
                        <a data-type="chapter-link" href="modules.html">
                            <div class="menu-toggler linked" data-toggle="collapse" ${ isNormalMode ?
                                'data-target="#modules-links"' : 'data-target="#xs-modules-links"' }>
                                <span class="icon ion-ios-archive"></span>
                                <span class="link-name">Modules</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                        </a>
                        <ul class="links collapse " ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                            <li class="link">
                                <a href="modules/AppModule.html" data-type="entity-link" >AppModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-AppModule-a9efae9c5030ab5c78a3fbc2f97eabfb2c63f18c71266e990347ba33836a19438a167594d4237ec264c0b6ba62da602429429199f6b456e721ad6da8c6a07f73"' : 'data-target="#xs-components-links-module-AppModule-a9efae9c5030ab5c78a3fbc2f97eabfb2c63f18c71266e990347ba33836a19438a167594d4237ec264c0b6ba62da602429429199f6b456e721ad6da8c6a07f73"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AppModule-a9efae9c5030ab5c78a3fbc2f97eabfb2c63f18c71266e990347ba33836a19438a167594d4237ec264c0b6ba62da602429429199f6b456e721ad6da8c6a07f73"' :
                                            'id="xs-components-links-module-AppModule-a9efae9c5030ab5c78a3fbc2f97eabfb2c63f18c71266e990347ba33836a19438a167594d4237ec264c0b6ba62da602429429199f6b456e721ad6da8c6a07f73"' }>
                                            <li class="link">
                                                <a href="components/AppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AppComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/EqualsTableComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EqualsTableComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/SubjectTreeAppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >SubjectTreeAppComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/SwaggerUIComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >SwaggerUIComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/EqualsTableModule.html" data-type="entity-link" >EqualsTableModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-EqualsTableModule-0a890ddc1a070ff8cf3f433989147d30cccf4e75f97cf67f889c172fc24fc71b0dd691e10ab6e1ddfd6f6132d27164c597bf4567ec450e393c9ac94b64ccb1d4"' : 'data-target="#xs-components-links-module-EqualsTableModule-0a890ddc1a070ff8cf3f433989147d30cccf4e75f97cf67f889c172fc24fc71b0dd691e10ab6e1ddfd6f6132d27164c597bf4567ec450e393c9ac94b64ccb1d4"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-EqualsTableModule-0a890ddc1a070ff8cf3f433989147d30cccf4e75f97cf67f889c172fc24fc71b0dd691e10ab6e1ddfd6f6132d27164c597bf4567ec450e393c9ac94b64ccb1d4"' :
                                            'id="xs-components-links-module-EqualsTableModule-0a890ddc1a070ff8cf3f433989147d30cccf4e75f97cf67f889c172fc24fc71b0dd691e10ab6e1ddfd6f6132d27164c597bf4567ec450e393c9ac94b64ccb1d4"' }>
                                            <li class="link">
                                                <a href="components/EqualslistComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EqualslistComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/SelectionComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >SelectionComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/HeaderModule.html" data-type="entity-link" >HeaderModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-HeaderModule-17fc0fed827966f3beb9aaf191392223a5e84598e2dae2cd94b66cd3f4a301e8b3ab6fdc5aa2bdc16dd6deff99e62bc1efad8236b5a5dc24f3c014fb4ea75729"' : 'data-target="#xs-components-links-module-HeaderModule-17fc0fed827966f3beb9aaf191392223a5e84598e2dae2cd94b66cd3f4a301e8b3ab6fdc5aa2bdc16dd6deff99e62bc1efad8236b5a5dc24f3c014fb4ea75729"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-HeaderModule-17fc0fed827966f3beb9aaf191392223a5e84598e2dae2cd94b66cd3f4a301e8b3ab6fdc5aa2bdc16dd6deff99e62bc1efad8236b5a5dc24f3c014fb4ea75729"' :
                                            'id="xs-components-links-module-HeaderModule-17fc0fed827966f3beb9aaf191392223a5e84598e2dae2cd94b66cd3f4a301e8b3ab6fdc5aa2bdc16dd6deff99e62bc1efad8236b5a5dc24f3c014fb4ea75729"' }>
                                            <li class="link">
                                                <a href="components/GlobalHeadComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >GlobalHeadComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/TreeHeadComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >TreeHeadComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/SharedModule.html" data-type="entity-link" >SharedModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/SubjectTreeModule.html" data-type="entity-link" >SubjectTreeModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-SubjectTreeModule-0bcd2f3e3cd3f9d94cd6cdc24352d6ca29215c9e75677010f6f4ced55ea80703b417ec53f39bbd9ac1e722fd75b5c99e5568e69fbd6d8c02fcca22af179d9200"' : 'data-target="#xs-components-links-module-SubjectTreeModule-0bcd2f3e3cd3f9d94cd6cdc24352d6ca29215c9e75677010f6f4ced55ea80703b417ec53f39bbd9ac1e722fd75b5c99e5568e69fbd6d8c02fcca22af179d9200"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-SubjectTreeModule-0bcd2f3e3cd3f9d94cd6cdc24352d6ca29215c9e75677010f6f4ced55ea80703b417ec53f39bbd9ac1e722fd75b5c99e5568e69fbd6d8c02fcca22af179d9200"' :
                                            'id="xs-components-links-module-SubjectTreeModule-0bcd2f3e3cd3f9d94cd6cdc24352d6ca29215c9e75677010f6f4ced55ea80703b417ec53f39bbd9ac1e722fd75b5c99e5568e69fbd6d8c02fcca22af179d9200"' }>
                                            <li class="link">
                                                <a href="components/SubjectComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >SubjectComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/TreeComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >TreeComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                </ul>
                </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#classes-links"' :
                            'data-target="#xs-classes-links"' }>
                            <span class="icon ion-ios-paper"></span>
                            <span>Classes</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="classes-links"' : 'id="xs-classes-links"' }>
                            <li class="link">
                                <a href="classes/EqualPair.html" data-type="entity-link" >EqualPair</a>
                            </li>
                            <li class="link">
                                <a href="classes/EqualsTable.html" data-type="entity-link" >EqualsTable</a>
                            </li>
                            <li class="link">
                                <a href="classes/EqualTableElement.html" data-type="entity-link" >EqualTableElement</a>
                            </li>
                            <li class="link">
                                <a href="classes/Subject.html" data-type="entity-link" >Subject</a>
                            </li>
                            <li class="link">
                                <a href="classes/Syllabus.html" data-type="entity-link" >Syllabus</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#injectables-links"' :
                                'data-target="#xs-injectables-links"' }>
                                <span class="icon ion-md-arrow-round-down"></span>
                                <span>Injectables</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                            <ul class="links collapse " ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                                <li class="link">
                                    <a href="injectables/CommonSettingsService.html" data-type="entity-link" >CommonSettingsService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/EventService.html" data-type="entity-link" >EventService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/RestClientService.html" data-type="entity-link" >RestClientService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/SubjectService.html" data-type="entity-link" >SubjectService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/SyllabiService.html" data-type="entity-link" >SyllabiService</a>
                                </li>
                            </ul>
                        </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#miscellaneous-links"'
                            : 'data-target="#xs-miscellaneous-links"' }>
                            <span class="icon ion-ios-cube"></span>
                            <span>Miscellaneous</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="miscellaneous-links"' : 'id="xs-miscellaneous-links"' }>
                            <li class="link">
                                <a href="miscellaneous/variables.html" data-type="entity-link">Variables</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <a data-type="chapter-link" href="coverage.html"><span class="icon ion-ios-stats"></span>Documentation coverage</a>
                    </li>
                    <li class="divider"></li>
                    <li class="copyright">
                        Documentation generated using <a href="https://compodoc.app/" target="_blank">
                            <img data-src="images/compodoc-vectorise.png" class="img-responsive" data-type="compodoc-logo">
                        </a>
                    </li>
            </ul>
        </nav>
        `);
        this.innerHTML = tp.strings;
    }
});